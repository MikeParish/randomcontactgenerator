﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace RandomContactGenerator
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Random Contact Generator"),
        ExportMetadata("Description", "Streamlines the creation of random contacts in Dataverse"),
    // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "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"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class RandomContactGenerator : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new RandomContactGeneratorControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public RandomContactGenerator()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);
                var assmbPath = Path.Combine(dir, $"{argName}.dll");
                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}