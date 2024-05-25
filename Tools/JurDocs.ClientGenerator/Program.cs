using JurDocs.ClientGenerator.Configurations;
using NSwag;
using NSwag.CodeGeneration.CSharp;

namespace JurClientGenerator
{
    internal class Program
    {

        private static readonly ClientGeneratorSettings _appSettings = new AppSettings().Settings;

        [SuppressMessage("Style", "IDE0060:Remove unused parameter")]
        static void Main(string[] args)
        {
            Console.WriteLine("JurDocs Client Generator!");

            var f = Run().GetAwaiter().GetResult();

            Console.WriteLine(f.Length);

            Console.Write("#");
            Console.ReadLine();
        }

        public static async Task<string> Run()
        {

            var document = await OpenApiYamlDocument.FromFileAsync(_appSettings.JurDocsYamlDoc);

            var settings = new CSharpClientGeneratorSettings
            {
                ClassName = "JurDocsClient",
                CSharpGeneratorSettings = {
                    Namespace = "JurDocs.Client",
                    GenerateJsonMethods = true,
                    DateType = "DateTime",
                    DateTimeType = "DateTime"
                },
                CodeGeneratorSettings = { 
                    //TemplateDirectory = "template",
                    ExcludedTypeNames=["JurDocType"],
                },
                GenerateResponseClasses = true,
                ResponseClass = "SwaggerResponse",
                WrapResponses = true,
                //ParameterDateFormat = "yyyyMMdd",
                //ParameterDateTimeFormat = "yyyyMMddHHmmss",
                GenerateDtoTypes = true,
                AdditionalNamespaceUsages = ["JurDocs.Common.EnumTypes"]
            };

            var generator = new CSharpClientGenerator(document, settings);
            var code = generator.GenerateFile();

            File.WriteAllText(_appSettings.JurDocsClientCodefile!, code);

            return code;
        }
    }
}
