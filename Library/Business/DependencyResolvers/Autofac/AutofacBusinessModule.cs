using Autofac;
using Business.Abstract;
using Business.Concrete;
using ExcelService.Abstract;
using ExcelService.Concrete;
using FileService.Abstract;
using FileService.Concrete;
using TemplateService.Abstract;
using TemplateService.Concrete;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        #region Business

        builder.RegisterType<DocumentGeneratorManager>().As<IDocumentGeneratorService>();

        #endregion

        #region Services

        builder.RegisterType<ExcelManager>().As<IExcelService>();
        builder.RegisterType<TemplateManager>().As<ITemplateService>();
        builder.RegisterType<FileManager>().As<IFileService>();

        #endregion
    }
}