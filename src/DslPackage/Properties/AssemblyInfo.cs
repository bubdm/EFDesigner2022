using System;
using System.Reflection;
using System.Resources;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

[assembly : AssemblyTitle("Entity Framework Visual Designer")]
[assembly : AssemblyDescription("Entity Framework visual design surface and code-first code generation for EF6, EFCore and beyond")]
#if DEBUG
[assembly : AssemblyConfiguration("Debug")]
#else
[assembly : AssemblyConfiguration("Release")]
#endif
[assembly : AssemblyCompany("Michael Sawczyn")]
[assembly : AssemblyProduct("EFDesigner")]
[assembly : AssemblyCopyright("Copyright � Michael Sawczyn 2017-2022")]
[assembly : AssemblyTrademark("")]
[assembly : AssemblyCulture("")]
[assembly : NeutralResourcesLanguage("en")]

[assembly : AssemblyVersion("4.2.1.0")]
[assembly : AssemblyFileVersion("4.2.1.0")]
[assembly : ComVisible(false)]
[assembly : CLSCompliant(false)]
[assembly : ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]