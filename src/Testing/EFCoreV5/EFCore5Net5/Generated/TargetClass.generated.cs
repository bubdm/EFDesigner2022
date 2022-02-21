//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v4.1.3.2
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Testing
{
   public partial class TargetClass: global::Testing.EntityAbstract
   {
      partial void Init();

      /// <summary>
      /// Default constructor
      /// </summary>
      public TargetClass(): base()
      {
         AssocClasses = new System.Collections.Generic.HashSet<global::Testing.AssocClass>();
         SourceClasses = new System.Collections.Generic.HashSet<global::Testing.SourceClass>();

         Init();
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Max length = 255
      /// </summary>
      [MaxLength(255)]
      [StringLength(255)]
      public string Test { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      /// <summary>
      /// Association class for SourceClasses
      /// </summary>
      [System.ComponentModel.Description("Association class for SourceClasses")]
      [System.ComponentModel.DataAnnotations.Display(Name="Association object for SourceClasses")]
      public virtual ICollection<global::Testing.AssocClass> AssocClasses { get; private set; }

      public virtual ICollection<global::Testing.SourceClass> SourceClasses { get; private set; }

   }
}

