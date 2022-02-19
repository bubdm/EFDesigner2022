using Sawczyn.EFDesigner.EFModel.Extensions;

using System;
using System.ComponentModel;

namespace Sawczyn.EFDesigner.EFModel
{
   partial class ModelDiagramData
   {
      private EFModelDiagram diagram;

      public EFModelDiagram GetDiagram() { return diagram; }
      public void SetDiagram(EFModelDiagram d) { diagram = d; }

      public static Action<ModelDiagramData> OpenDiagram { get; set; }
      public static Action<EFModelDiagram> CloseDiagram { get; set; }
      public static Action<EFModelDiagram> RenameWindow { get; set; }

      /// <summary>
      /// The output directory for this element's code before overrides
      /// </summary>
      [Browsable(false)]
      public string DefaultOutputDirectory
      {
         get
         {
            return string.IsNullOrWhiteSpace(ModelRoot?.MermaidOutputDirectory)
                      ? ModelRoot?.ContextOutputDirectory
                      : ModelRoot.MermaidOutputDirectory;
         }
      }

      /// <summary>
      /// Output directory for generated code. Takes overrides into account.
      /// </summary>
      [Browsable(false)]
      // ReSharper disable once UnusedMember.Global
      public string EffectiveOutputDirectory
      {
         get
         {
            return outputDirectoryStorage ?? DefaultOutputDirectory;
         }
      }

      #region OutputDirectory tracking property

      private string outputDirectoryStorage;

      private string GetOutputDirectoryValue()
      {
         if (!this.IsLoading() && IsOutputDirectoryTracking)
         {
            try
            {
               return DefaultOutputDirectory;
            }
            catch (NullReferenceException)
            {
               return default;
            }
            catch (Exception e)
            {
               if (CriticalException.IsCriticalException(e))
                  throw;

               return default;
            }
         }

         return outputDirectoryStorage;
      }

      private void SetOutputDirectoryValue(string value)
      {
         outputDirectoryStorage = string.IsNullOrWhiteSpace(value) || value == DefaultOutputDirectory ? null : value;

         if (!Store.InUndoRedoOrRollback && !this.IsLoading())
            IsOutputDirectoryTracking = outputDirectoryStorage == null;
      }

      /// <summary>
      ///    Calls the pre-reset method on the associated property value handler for each
      ///    tracking property of this model element.
      /// </summary>
      internal virtual void PreResetIsTrackingProperties()
      {
         IsOutputDirectoryTrackingPropertyHandler.Instance.PreResetValue(this);
         // same with other tracking properties as they get added
      }

      /// <summary>
      ///    Calls the reset method on the associated property value handler for each
      ///    tracking property of this model element.
      /// </summary>
      internal virtual void ResetIsTrackingProperties()
      {
         IsOutputDirectoryTrackingPropertyHandler.Instance.ResetValue(this);
         // same with other tracking properties as they get added
      }

      internal sealed partial class IsOutputDirectoryTrackingPropertyHandler
      {
         /// <summary>Performs the reset operation for the IsOutputDirectoryTracking property for a model element.</summary>
         /// <param name="element">The model element that has the property to reset.</param>
         internal void ResetValue(ModelDiagramData element)
         {
            element.isOutputDirectoryTrackingPropertyStorage = string.IsNullOrWhiteSpace(element.outputDirectoryStorage);
         }

         /// <summary>
         ///    Method to set IsOutputDirectoryTracking to false so that this instance of this tracking property is not
         ///    storage-based.
         /// </summary>
         /// <param name="element">
         ///    The element on which to reset the property
         ///    value.
         /// </param>
         internal void PreResetValue(ModelDiagramData element) =>
            // Force the IsOutputDirectoryTracking property to false so that the value  
            // of the OutputDirectory property is retrieved from storage.  
            element.isOutputDirectoryTrackingPropertyStorage = false;
      }

      #endregion OutputDirectory tracking property
   }
}