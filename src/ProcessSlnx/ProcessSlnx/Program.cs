// See https://aka.ms/new-console-template for more information

namespace ProcessSlnx;

using System.Xml;
using Microsoft.VisualBasic;
using static System.Console;

internal static class Program
{
    private const char ARG = '-';
    private const string ADD = "add";
    private const string ALL = "all";
    private const string FILE = "file";
    private const string FILES = "files";
    private const string HELP = "help";
    private const string LIST = "list";
    private const string CREATE = "new";
    private const string REMOVE = "remove";

    private const string SLNX = ".slnx";

    private static string? command;
    private static string? subCommand;
    private static string? filename;
    private static string? filePath;
    private static string? projectPath;
    private static bool force;
    private static bool deploy;
    private static bool solutionItems;

    private static readonly string WorkingDir = Environment.CurrentDirectory;

    public static async Task<int> Main(string[] args)
    {
#if DEBUG
        Write("Press any key to continue . . .");
        ReadKey();
        WriteLine();
        WriteLine();
#endif

        var result = ValidateInput(args);

        if (!result.Valid)
        {
            WriteErrorMessage(result.Message);
            return result.Code;
        }

        if (command == HELP)
        {
            WriteHelpMessage();
            return 0;
        }

        string solutionPath;

        if (command == CREATE)
        {
            string template;

            if (solutionItems)
            {
                template = """
                <Solution>
                    <Folder Name="/Solution Items/">
                    </Folder>
                    <Properties Name="Visual Studio">
                        <!-- Support is provisionally available on Visual Studio 17.10 and later versions. -->
                        <Property Name="OpenWith" Value="17" />
                    </Properties>
                </Solution>

                """;
            }
            else
            {
                template = """
                <Solution>
                    <Properties Name="Visual Studio">
                        <!-- Support is provisionally available on Visual Studio 17.10 and later versions. -->
                        <Property Name="OpenWith" Value="17" />
                    </Properties>
                </Solution>

                """;
            }

            var rootPath = Path.GetPathRoot(WorkingDir);

            try
            {
                if (string.IsNullOrEmpty(filename))
                {
                    filename = WorkingDir == rootPath ? rootPath[0].ToString() : Path.GetFileName(WorkingDir);
                }

                solutionPath = Path.Combine(WorkingDir, $"{filename}.slnx");

                if (!force)
                {
                    if (File.Exists(solutionPath))
                    {
                        WriteErrorMessage("Creating this template will make changes to existing files:");
                        WriteErrorMessage($"  Overwrite   ./{filename}.slnx");
                        WriteErrorMessage($"{Environment.NewLine}To create the template anyway, run the command with '--force' option:");
                        WriteInfoMessage("   slnx new --force");
                        return 73;
                    }
                }

                await File.WriteAllTextAsync(solutionPath, template);
                WriteInfoMessage("The template \"Solution File\" was created successfully.");
            }
            catch (Exception ex)
            {
                WriteErrorMessage($"Error occurred while creating - {ex.Message}");
            }

            return 0;
        }
        else if (command is ADD or LIST or REMOVE)
        {
            if (string.IsNullOrEmpty(filename))
            {
                var solutions = Directory.GetFiles(WorkingDir, "*.slnx");

                if (solutions.Length == 0)
                {
                    WriteErrorMessage($"Specified solution file {WorkingDir} does not exist, or there is no solution (slnx) file in the directory.");
                    return 1;
                }
                else if (solutions.Length > 1)
                {
                    WriteErrorMessage($"Found more than one solution (slnx) file in {WorkingDir}. Specify which one to use.");
                    return 1;
                }
                else
                {
                    solutionPath = solutions[0];
                }
            }
            else
            {
                solutionPath = Path.Combine(WorkingDir, filename);
            }

            if (!(Directory.Exists(solutionPath) || File.Exists(solutionPath)))
            {
                WriteErrorMessage($"Could not find solution or directory `{filename}`.");
                return 1;
            }

            try
            {
                switch (command)
                {
                    case ADD:
                        await ProcessAddCommand(solutionPath);
                        break;
                    case LIST:
                        await ProcessListCommand(solutionPath);
                        break;
                    case REMOVE:
                        await ProcessRemoveCommand(solutionPath);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteErrorMessage($"Error occurred while processing - {ex.Message}");
            }
        }

        return 0;
    }

    private static ValidationResult ValidateInput(string[] args)
    {
        if (args.Length == 0)
        {
            return new(false, 1, "Required command was not provided.");
        }
        else if (args.Length == 1)
        {
            var param1 = args[0].ToLowerInvariant();

            if (param1 is CREATE or LIST)
            {
                command = param1;
            }
            else if (param1 is ADD or REMOVE)
            {
                command = param1;
                return new(false, 1, $"You must specify at least one project to {command}.");
            }
            else if (param1 is "-h" or "-?" or "--help")
            {
                command = HELP;
            }
            else
            {
                return new(false, 1, "Required command was not provided.");
            }
        }
        else if (args.Length == 2)
        {
            var param1 = args[0].ToLowerInvariant();
            var param2 = args[1].ToLowerInvariant();
            var solutionFile = param1.EndsWith(SLNX, StringComparison.InvariantCultureIgnoreCase);

            if (solutionFile)
            {
                if (param2 == LIST)
                {
                    filename = args[0];
                    command = LIST;
                }
                else if (param2 is ADD or REMOVE)
                {
                    return new(false, 1, $"You must specify at least one project to {command}.");
                }
                else
                {
                    return new(false, 1, "Required command was not provided.");
                }
            }
            else if (param1 == CREATE)
            {
                command = CREATE;

                if (param2 == "--force")
                {
                    force = true;
                }
                else if (param2 is "-isi" or "--include-solution-items")
                {
                    solutionItems = true;
                }
                else if (param2.StartsWith(ARG))
                {
                    return new(false, 1, $"Unrecognized command or argument '{args[1]}'.");
                }
                else
                {
                    filename = args[1];
                }
            }
            else if (param1 is ADD or REMOVE)
            {
                command = param1;

                if (param2.StartsWith(ARG))
                {
                    return new(false, 1, $"Unrecognized command or argument '{args[1]}'.");
                }
                else
                {
                    projectPath = args[1];
                }
            }
            else if (param1 == LIST)
            {
                command = LIST;

                if (param2 == ALL)
                {
                    subCommand = ALL;
                }
                else if (param2 == FILES)
                {
                    subCommand = FILES;
                }
                else
                {
                    return new(false, 1, $"Unrecognized command or argument '{args[1]}'.");
                }
            }
            else
            {
                return new(false, 1, "Required command was not provided.");
            }
        }
        else if (args.Length == 3)
        {
            var param1 = args[0].ToLowerInvariant();
            var param2 = args[1].ToLowerInvariant();
            var param3 = args[2].ToLowerInvariant();
            var solutionFile = param1.EndsWith(SLNX, StringComparison.InvariantCultureIgnoreCase);

            if (solutionFile)
            {
                if (param2 == CREATE)
                {
                    if (param3 == "--force")
                    {
                        force = true;
                    }
                    else if (param3 is "-isi" or "--include-solution-items")
                    {
                        solutionItems = true;
                    }
                    else
                    {
                        return new(false, 1, $"Unrecognized command or argument '{args[2]}'.");
                    }
                }
                else if (param2 is ADD or REMOVE)
                {
                    filename = args[0];
                    command = param2;

                    if (param3 == FILE)
                    {
                        return new(false, 1, $"You must specify at least one file to {command}.");
                    }
                    else if (param3.StartsWith(ARG))
                    {
                        return new(false, 1, $"Unrecognized command or argument '{args[2]}'.");
                    }
                    else
                    {
                        projectPath = args[2];
                    }
                }
                else if (param2 == LIST)
                {
                    filename = args[0];
                    command = LIST;

                    if (param3 == ALL)
                    {
                        subCommand = ALL;
                    }
                    else if (param3 == FILES)
                    {
                        subCommand = FILES;
                    }
                    else
                    {
                        return new(false, 1, $"Unrecognized command or argument '{args[2]}'.");
                    }
                }
                else
                {
                    return new(false, 1, "Required command was not provided.");
                }
            }
            else if (param1 == CREATE)
            {
                if (param2.StartsWith(ARG) && !param3.StartsWith(ARG))
                {
                    return new(false, 1, $"Unrecognized command or argument '{args[2]}'.");
                }

                command = CREATE;

                // First option

                if (param2 == "--force")
                {
                    force = true;
                }
                else if (param2 is "-isi" or "--include-solution-items")
                {
                    solutionItems = true;
                }
                else if (!param2.StartsWith(ARG))
                {
                    filename = args[1];
                }
                else
                {
                    return new(false, 1, $"Unrecognized command or argument '{args[1]}'.");
                }

                // Second option

                if (param3 == "--force")
                {
                    force = true;
                }
                else if (param3 is "-isi" or "--include-solution-items")
                {
                    solutionItems = true;
                }
                else
                {
                    return new(false, 1, $"Unrecognized command or argument '{args[2]}'.");
                }
            }
            else if (param1 is ADD or REMOVE)
            {
                command = param1;

                if (param2 == FILE)
                {
                    if (param3.StartsWith(ARG))
                    {
                        return new(false, 1, $"Unrecognized command or argument '{args[2]}'.");
                    }
                    else
                    {
                        subCommand = FILE;
                        filePath = args[2];
                    }
                }
                else
                {
                    if (param2.StartsWith(ARG))
                    {
                        return new(false, 1, $"Unrecognized command or argument '{args[1]}'.");
                    }
                    else
                    {
                        projectPath = args[1];
                    }

                    if (param1 == ADD && param3 is "-d" or "--deploy")
                    {
                        deploy = true;
                    }
                    else
                    {
                        return new(false, 1, $"Unrecognized command or argument '{args[2]}'.");
                    }
                }
            }
            else
            {
                return new(false, 1, "Required command was not provided.");
            }
        }
        else if (args.Length == 4)
        {
            var param1 = args[0].ToLowerInvariant();
            var param2 = args[1].ToLowerInvariant();
            var param3 = args[2].ToLowerInvariant();
            var param4 = args[3].ToLowerInvariant();
            var solutionFile = param1.EndsWith(SLNX, StringComparison.InvariantCultureIgnoreCase);

            if (solutionFile)
            {
                if (param2 == ADD)
                {
                    if (param3 == FILE)
                    {
                        if (param4.StartsWith(ARG))
                        {
                            return new(false, 1, $"Unrecognized command or argument '{args[3]}'.");
                        }
                        else
                        {
                            filename = args[0];
                            command = ADD;
                            subCommand = FILE;
                            filePath = args[3];
                        }
                    }
                    else
                    {
                        if (param3.StartsWith(ARG) && !param4.StartsWith(ARG))
                        {
                            return new(false, 1, $"Unrecognized command or argument '{args[3]}'.");
                        }

                        filename = args[0];
                        command = ADD;
                        projectPath = args[2];

                        if (param4 is "-d" or "--deploy")
                        {
                            deploy = true;
                        }
                        else
                        {
                            return new(false, 1, $"Unrecognized command or argument '{args[3]}'.");
                        }
                    }
                }
                else if (param2 == REMOVE)
                {
                    if (param3 == FILE)
                    {
                        if (param4.StartsWith(ARG))
                        {
                            return new(false, 1, $"Unrecognized command or argument '{args[3]}'.");
                        }
                        else
                        {
                            filename = args[0];
                            command = REMOVE;
                            subCommand = FILE;
                            filePath = args[3];
                        }
                    }
                    else
                    {
                        return new(false, 1, $"Unrecognized command or argument '{args[3]}'.");
                    }
                }
                else
                {
                    return new(false, 1, "Required command was not provided.");
                }
            }
            else if (param1 == CREATE)
            {
                if (param2.StartsWith(ARG) && !(param3.StartsWith(ARG) || param4.StartsWith(ARG)))
                {
                    return new(false, 1, $"Unrecognized command or argument '{args[2]}'.");
                }

                command = CREATE;

                // First option

                if (param2.StartsWith(ARG))
                {
                    return new(false, 1, $"Unrecognized command or argument '{args[1]}'.");
                }
                else
                {
                    filename = args[1];
                }

                // Second option

                if (param3 == "--force")
                {
                    force = true;
                }
                else if (param3 is "-isi" or "--include-solution-items")
                {
                    solutionItems = true;
                }
                else
                {
                    return new(false, 1, $"Unrecognized command or argument '{args[2]}'.");
                }

                // Third option

                if (param4 == "--force")
                {
                    force = true;
                }
                else if (param4 is "-isi" or "--include-solution-items")
                {
                    solutionItems = true;
                }
                else
                {
                    return new(false, 1, $"Unrecognized command or argument '{args[3]}'.");
                }
            }
            else
            {
                return new(false, 1, "Required command was not provided.");
            }
        }
        else
        {
            return new(false, 1, "Required command was not provided.");
        }

        return new(true);
    }

    private static async Task<int> ProcessAddCommand(string solution)
    {
        ArgumentNullException.ThrowIfNull(solution, nameof(solution));

        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(await File.ReadAllTextAsync(solution));

        if (xmlDoc is null || xmlDoc.DocumentElement is null)
        {
            return 1;
        }

        var properties = xmlDoc.SelectSingleNode("/Solution/Properties");

        if (string.IsNullOrEmpty(subCommand))
        {
            var projectNode = xmlDoc.SelectSingleNode($"//Project[@Path='{projectPath.XmlEncode()}']");

            if (projectNode is null)
            {
                var fullPath = Path.Combine(WorkingDir, projectPath!);

                if (File.Exists(fullPath))
                {
                    try
                    {
                        var projDoc = new XmlDocument();
                        projDoc.LoadXml(await File.ReadAllTextAsync(fullPath));

                        if (projDoc is null
                            || projDoc.DocumentElement is null
                            || projDoc.DocumentElement.Name is not "Project")
                        {
                            WriteInfoMessage($"Invalid project `{fullPath}`. The element <{projDoc?.DocumentElement?.Name}> is unrecognized, or not supported in this context.");
                            return 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteInfoMessage($"Invalid project `{fullPath}`. The project file could not be loaded. {ex.Message}");
                        return 0;
                    }
                }
                else
                {
                    WriteErrorMessage($"Could not find project or directory `{projectPath}`.");
                    return 1;
                }

                var addProject = xmlDoc.CreateElement("Project");
                var path = xmlDoc.CreateAttribute("Path");
                path.Value = projectPath.XmlEncode();
                _ = addProject.Attributes.Append(path);

                if (deploy)
                {
                    var deploy = xmlDoc.CreateElement("Deploy");
                    _ = addProject.AppendChild(deploy);
                }

                _ = xmlDoc.DocumentElement.InsertBefore(addProject, properties);
                xmlDoc.Save(solution);
                WriteInfoMessage($"Project `{projectPath}` added to the solution.");
            }
            else
            {
                WriteInfoMessage($"Solution {solution} already contains project {projectPath}.");
            }
        }
        else
        {
            var fileNode = xmlDoc.SelectSingleNode($"/Solution/Folder[@Name='/Solution Items/']/File[@Path='{filePath.XmlEncode()}']");

            if (fileNode is null)
            {
                var fullPath = Path.Combine(WorkingDir, filePath!);

                if (!File.Exists(fullPath))
                {
                    WriteInfoMessage($"Could not find file `{fullPath}`.");
                    return 1;
                }

                var itemsNode = xmlDoc.SelectSingleNode($"/Solution/Folder[@Name='/Solution Items/']");

                var addFile = xmlDoc.CreateElement("File");
                var path = xmlDoc.CreateAttribute("Path");
                path.Value = filePath.XmlEncode();
                _ = addFile.Attributes.Append(path);

                if (itemsNode is null)
                {
                    var addFolder = xmlDoc.CreateElement("Folder");
                    var name = xmlDoc.CreateAttribute("Name");
                    name.Value = "/Solution Items/";
                    _ = addFolder.Attributes.Append(name);
                    _ = addFolder.AppendChild(addFile);
                    _ = xmlDoc.DocumentElement.PrependChild(addFolder);
                }
                else
                {
                    _ = itemsNode.AppendChild(addFile);
                }

                xmlDoc.Save(solution);
                WriteInfoMessage($"File `{filePath}` added to the solution.");
            }
            else
            {
                WriteInfoMessage($"Solution {solution} already contains file {filePath}.");
            }
        }

        return 0;
    }

    private static async Task ProcessListCommand(string solution)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(await File.ReadAllTextAsync(solution));

        if (xmlDoc is null || xmlDoc.DocumentElement is null)
        {
            return;
        }

        if (subCommand == ALL || subCommand == FILES)
        {
            var files = xmlDoc.SelectNodes("//File");

            if (files?.Count > 0)
            {
                WriteInfoMessage("File(s)");
                WriteInfoMessage("-------");

                foreach (XmlNode file in files)
                {
                    WriteInfoMessage(file?.Attributes?["Path"]?.Value?.XmlDecode());
                }
            }
            else
            {
                WriteInfoMessage("No files found in the solution.");
            }

            if (subCommand == FILES)
            {
                return;
            }

            WriteLine();
        }

        var projects = xmlDoc.SelectNodes("//Project");

        if (projects?.Count > 0)
        {
            WriteInfoMessage("Project(s)");
            WriteInfoMessage("----------");

            foreach (XmlNode project in projects)
            {
                WriteInfoMessage(project?.Attributes?["Path"]?.Value?.XmlDecode());
            }
        }
        else
        {
            WriteInfoMessage("No projects found in the solution.");
        }
    }

    private static async Task ProcessRemoveCommand(string solution)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(await File.ReadAllTextAsync(solution));

        if (xmlDoc is null || xmlDoc.DocumentElement is null)
        {
            return;
        }

        if (string.IsNullOrEmpty(subCommand))
        {
            var removeProject = xmlDoc.SelectSingleNode($"//Project[@Path='{projectPath.XmlEncode()}']");

            if (removeProject is not null)
            {
                xmlDoc.DocumentElement.RemoveChild(removeProject);
                xmlDoc.Save(solution);

                WriteInfoMessage($"Project `{projectPath}` removed from the solution.");
            }
            else
            {
                WriteInfoMessage($"Project `{projectPath}` could not be found in the solution.");
            }
        }
        else
        {
            var fileNode = xmlDoc.SelectSingleNode($"/Solution/Folder[@Name='/Solution Items/']/File[@Path='{filePath.XmlEncode()}']");

            if (fileNode is not null)
            {
                var itemsNode = xmlDoc.SelectSingleNode($"/Solution/Folder[@Name='/Solution Items/']");
                itemsNode?.RemoveChild(fileNode);
                xmlDoc.Save(solution);

                WriteInfoMessage($"File `{filePath}` removed from the solution.");
            }
            else
            {
                WriteInfoMessage($"File `{filePath}` could not be found in the solution.");
            }
        }
    }

    private static void WriteHelpMessage()
    {
        WriteInfoMessage("Description:");
        WriteInfoMessage("  .NET modify solution (slnx) file command");
        WriteLine();
        WriteInfoMessage("Usage:");
        WriteInfoMessage("  slnx <SLN_FILE> [command] [options]");
        WriteLine();
        WriteInfoMessage("Arguments:");
        WriteInfoMessage("  <SLN_FILE>  The solution file to operate on. If not specified, the command will search the current directory for one.");
        WriteLine();
        WriteInfoMessage("Options:");
        WriteInfoMessage("  -?, -h, --help  Show command line help.");
        WriteLine();
        WriteInfoMessage("Commands:");
        WriteInfoMessage("  add <PROJECT_PATH>     Add one or more projects to a solution file.");
        WriteInfoMessage("  list                   List all projects in a solution file.");
        WriteInfoMessage("  remove <PROJECT_PATH>  Remove one or more projects from a solution file.");
    }

    private static void WriteErrorMessage(string message)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(message);
        ResetColor();
    }

    private static void WriteInfoMessage(string? message) => WriteLine(message);

    private static string? XmlEncode(this string? value) => value?.Replace("&", "&amp;");

    private static string? XmlDecode(this string? value) => value?.Replace("&amp;", "&");
}

internal sealed record ValidationResult(bool Valid, int Code = 0, string Message = "");
