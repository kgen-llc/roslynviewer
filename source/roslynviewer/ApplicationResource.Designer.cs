//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace roslynviewer {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    ///   This class was generated by MSBuild using the GenerateResource task.
    ///   To add or remove a member, edit your .resx file then rerun MSBuild.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Build.Tasks.StronglyTypedResourceBuilder", "15.1.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ApplicationResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ApplicationResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("roslynviewer.ApplicationResource", typeof(ApplicationResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to _About.
        /// </summary>
        public static string AboutMenuHeader {
            get {
                return ResourceManager.GetString("AboutMenuHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to _Exit.
        /// </summary>
        public static string ExitMenuHeader {
            get {
                return ResourceManager.GetString("ExitMenuHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to _File.
        /// </summary>
        public static string FileMenuHeader {
            get {
                return ResourceManager.GetString("FileMenuHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select a Roslyn Tree node.
        /// </summary>
        public static string NodeDisplayWatermark {
            get {
                return ResourceManager.GetString("NodeDisplayWatermark", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Roslyn Syntax Tree :.
        /// </summary>
        public static string RoslynTreeHeader {
            get {
                return ResourceManager.GetString("RoslynTreeHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Source code :.
        /// </summary>
        public static string SourceCodeHeader {
            get {
                return ResourceManager.GetString("SourceCodeHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter your source code to be analyzed.
        /// </summary>
        public static string SourceCodeWatermark {
            get {
                return ResourceManager.GetString("SourceCodeWatermark", resourceCulture);
            }
        }
    }
}
