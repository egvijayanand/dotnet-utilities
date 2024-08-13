// See https://aka.ms/new-console-template for more information

using System.Xml;
using static System.Console;

namespace ProcessSlnx;

static class Program
{
    const string ADD = "add";
    const string HELP = "help";
    const string LIST = "list";
    const string CREATE = "new";
    const string REMOVE = "remove";

    static string? _command;
    static string? _filename;
    static string? _projectPath;
    static bool _force;

    static async Task<int> Main(string[] args)
    {
        var result = ValidateInput(args);

        if (!result.Valid)
        {
            WriteErrorMessage(result.Message);
            return result.Code;
        }

        if (_command == HELP)
        {
            WriteHelpMessage();
            return 0;
        }

        string solution;
        var workingDir = Environment.CurrentDirectory;

        if (_command == "new")
        {
            var template = """
                <Solution>
                    <Properties Name="Visual Studio">
                        <!-- Support is provisionally available on Visual Studio 17.10 and later versions. -->
                        <Property Name="OpenWith" Value="17" />
                    </Properties>
                </Solution>
                """;

            var rootPath = Path.GetPathRoot(workingDir);

            try
            {
                if (string.IsNullOrEmpty(_filename))
                {
                    _filename = workingDir == rootPath ? rootPath[0].ToString() : Path.GetFileName(workingDir);
                }

                solution = Path.Combine(workingDir, $"{_filename}.slnx");

                if (!_force)
                {
                    if (File.Exists(solution))
                    {
                        WriteErrorMessage("Creating this template will make changes to existing files:");
                        WriteErrorMessage($"  Overwrite   ./{_filename}.slnx");
                        WriteErrorMessage($"{Environment.NewLine}To create the template anyway, run the command with '--force' option:");
                        WriteInfoMessage("   slnx new --force");
                        return 73;
                    }
                }

                await File.WriteAllTextAsync(solution, template);
                WriteInfoMessage("The template \"Solution File\" was created successfully.");
            }
            catch (Exception ex)
            {
                WriteErrorMessage($"Error occurred while creating - {ex.Message}");
            }

            return 0;
        }
        else if (_command == ADD || _command == LIST || _command == REMOVE)
        {
            if (string.IsNullOrEmpty(_filename))
            {
                var solutions = Directory.GetFiles(workingDir, "*.slnx");

                if (solutions.Length == 0)
                {
                    WriteErrorMessage($"Specified solution file {workingDir} does not exist, or there is no solution (slnx) file in the directory.");
                    return 0;
                }

                solution = solutions[0];
            }
            else
            {
                solution = Path.Combine(workingDir, _filename);
            }

            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(await File.ReadAllTextAsync(solution));

                if (xmlDoc is null || xmlDoc.DocumentElement is null)
                {
                    return 0;
                }

                switch (_command)
                {
                    case ADD:
                        var projectNode = xmlDoc.SelectSingleNode($"//Project[@Path='{_projectPath.XmlEncode()}']");

                        if (projectNode is null)
                        {
                            var properties = xmlDoc.SelectSingleNode("/Solution/Properties");
                            var addProject = xmlDoc.CreateElement("Project");
                            var path = xmlDoc.CreateAttribute("Path");
                            path.Value = _projectPath.XmlEncode();
                            addProject.Attributes.Append(path);
                            xmlDoc.DocumentElement.InsertBefore(addProject, properties);
                            xmlDoc.Save(solution);
                            WriteInfoMessage($"Project `{_projectPath}` added to the solution.");
                        }
                        else
                        {
                            WriteInfoMessage($"Solution {solution} already contains project {_projectPath}.");
                        }

                        break;
                    case LIST:
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

                        break;
                    case REMOVE:
                        var removeProject = xmlDoc.SelectSingleNode($"//Project[@Path='{_projectPath.XmlEncode()}']");

                        if (removeProject is not null)
                        {
                            xmlDoc.DocumentElement.RemoveChild(removeProject);
                            xmlDoc.Save(solution);

                            WriteInfoMessage($"Project `{_projectPath}` removed from the solution.");
                        }
                        else
                        {
                            WriteInfoMessage($"Project `{_projectPath}` could not be found in the solution.");
                        }

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

    static ValidationResult ValidateInput(string[] args)
    {
        if (args.Length == 0)
        {
            return new(false, 1, "Required command was not provided.");
        }
        else if (args.Length == 1)
        {
            var param1 = args[0].ToLowerInvariant();

            if (param1 == CREATE || param1 == LIST)
            {
                _command = param1;
                return new(true);
            }
            else if (param1 == ADD || param1 == REMOVE)
            {
                _command = param1;
                return new(false, 1, $"You must specify at least one project to {_command}.");
            }
            else if (param1 == "-h" || param1 == "-?" || param1 == "--help")
            {
                _command = HELP;
                return new(true);
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
            var solnFile = param1.EndsWith(".slnx");

            // Validation for default solution file

            if (param1 == CREATE)
            {
                _command = param1;

                if (param2 == "--force")
                {
                    _force = true;
                }
                else
                {
                    _filename = args[1];
                }
            }
            else if (param1 == ADD || param1 == REMOVE)
            {
                _command = param1;
                _projectPath = args[1];
            }
            else if (param1 == LIST)
            {
                return new(false, 1, $"Unrecognized command or argument '{args[1]}'.");
            }
            else if (solnFile)
            {
                // Validation for explicit solution file.
                if (param2 == LIST)
                {
                    _filename = args[0];
                    _command = param2;
                }
                else if (param2 == ADD || param2 == REMOVE)
                {
                    return new(false, 1, $"You must specify at least one project to {_command}.");
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
        }
        else if (args.Length == 3)
        {
            var param1 = args[0].ToLowerInvariant();
            var param2 = args[1].ToLowerInvariant();
            var param3 = args[2].ToLowerInvariant();
            var solnFile = param1.EndsWith(".slnx");

            if (param2 == ADD || param2 == REMOVE)
            {
                if (solnFile)
                {
                    _filename = args[0];
                    _command = param2;
                    _projectPath = args[2];
                }
                else
                {
                    return new(false, 1, $"Unrecognized command or argument '{args[0]}'.");
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

    static void WriteHelpMessage()
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

    static void WriteErrorMessage(string message)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(message);
        ResetColor();
    }

    static void WriteInfoMessage(string? message) => WriteLine(message);

    static string? XmlEncode(this string? value) => value?.Replace("&", "&amp;");

    static string? XmlDecode(this string? value) => value?.Replace("&amp;", "&");
}

record ValidationResult(bool Valid, int Code = 0, string Message = "");
