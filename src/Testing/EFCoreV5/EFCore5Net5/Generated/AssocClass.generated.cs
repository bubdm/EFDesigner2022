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
   public partial class AssocClass
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected AssocClass()
      {
         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static AssocClass CreateAssocClassUnsafe()
      {
         return new AssocClass();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="id">Unique identifier</param>
      /// <param name="sourceclassesid">Foreign key for SourceClass.AssocClasses &lt;--&gt; AssocClass.SourceClass. </param>
      /// <param name="targetclassesid">Foreign key for TargetClass.AssocClasses &lt;--&gt; AssocClass.TargetClass. </param>
      /// <param name="targetclass">Association class for TargetClasses</param>
      /// <param name="sourceclass">Association class for SourceClasses</param>
      public AssocClass(long id, long sourceclassesid, long targetclassesid, global::Testing.TargetClass targetclass, global::Testing.SourceClass sourceclass)
      {
         this.Id = id;

         this.SourceClassesId = sourceclassesid;

         this.TargetClassesId = targetclassesid;

         if (targetclass == null) throw new ArgumentNullException(nameof(targetclass));
         this.TargetClass = targetclass;
         targetclass.AssocClasses.Add(this);

         if (sourceclass == null) throw new ArgumentNullException(nameof(sourceclass));
         this.SourceClass = sourceclass;
         sourceclass.AssocClasses.Add(this);

         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="id">Unique identifier</param>
      /// <param name="sourceclassesid">Foreign key for SourceClass.AssocClasses &lt;--&gt; AssocClass.SourceClass. </param>
      /// <param name="targetclassesid">Foreign key for TargetClass.AssocClasses &lt;--&gt; AssocClass.TargetClass. </param>
      /// <param name="targetclass">Association class for TargetClasses</param>
      /// <param name="sourceclass">Association class for SourceClasses</param>
      public static AssocClass Create(long id, long sourceclassesid, long targetclassesid, global::Testing.TargetClass targetclass, global::Testing.SourceClass sourceclass)
      {
         return new AssocClass(id, sourceclassesid, targetclassesid, targetclass, sourceclass);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Indexed, Required
      /// Unique identifier
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Unique identifier")]
      public long Id { get; set; }

      /// <summary>
      /// Identity, Indexed, Required
      /// Foreign key for SourceClass.AssocClasses &lt;--&gt; AssocClass.SourceClass. 
      /// </summary>
      [Key]
      [Required]
      [System.ComponentModel.Description("Foreign key for SourceClass.AssocClasses <--> AssocClass.SourceClass. ")]
      public long SourceClassesId { get; set; }

      /// <summary>
      /// Identity, Indexed, Required
      /// Foreign key for TargetClass.AssocClasses &lt;--&gt; AssocClass.TargetClass. 
      /// </summary>
      [Key]
      [Required]
      [System.ComponentModel.Description("Foreign key for TargetClass.AssocClasses <--> AssocClass.TargetClass. ")]
      public long TargetClassesId { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      /// <summary>
      /// Required&lt;br/&gt;
      /// Association class for SourceClasses
      /// </summary>
      [System.ComponentModel.Description("Association class for SourceClasses")]
      [System.ComponentModel.DataAnnotations.Display(Name="Association object for SourceClasses")]
      public virtual global::Testing.SourceClass SourceClass { get; set; }

      /// <summary>
      /// Required&lt;br/&gt;
      /// Association class for TargetClasses
      /// </summary>
      [System.ComponentModel.Description("Association class for TargetClasses")]
      [System.ComponentModel.DataAnnotations.Display(Name="Association object for TargetClasses")]
      public virtual global::Testing.TargetClass TargetClass { get; set; }

   }
}

