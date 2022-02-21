using System;
using System.ComponentModel;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Design;

namespace Sawczyn.EFDesigner.EFModel
{
   public partial class ModelDiagramDataTypeDescriptor
   {
      private DomainDataDirectory storeDomainDataDirectory;

      /// <summary>
      ///    Returns the property descriptors for the described ModelDiagramData domain class, adding tracking property
      ///    descriptor(s).
      /// </summary>
      private PropertyDescriptorCollection GetCustomProperties(Attribute[] attributes)
      {
         // Get the default property descriptors from the base class  
         PropertyDescriptorCollection propertyDescriptors = base.GetProperties(attributes);

         //Add the descriptor for the tracking property.  
         if (ModelElement is ModelDiagramData diagramData)
         {
            storeDomainDataDirectory = diagramData.Store.DomainDataDirectory;

            // if the name of the diagram is the name of the model file, it's the default diagram. Can't modify it, so remove the temptation.
            if (diagramData.Name == System.IO.Path.GetFileNameWithoutExtension(diagramData.ModelRoot.GetFileName()))
               propertyDescriptors.Remove("Name");

            ;
            //Add the descriptors for the tracking properties 

            if (diagramData.GenerateMermaid)
            {
               propertyDescriptors.Add(new TrackingPropertyDescriptor(diagramData
                                                                    , storeDomainDataDirectory.GetDomainProperty(ModelDiagramData.OutputDirectoryDomainPropertyId)
                                                                    , storeDomainDataDirectory.GetDomainProperty(ModelDiagramData.IsOutputDirectoryTrackingDomainPropertyId)
                                                                    , new Attribute[]
                                                                      {
                                                                         new DisplayNameAttribute("Output Directory")
                                                                       , new DescriptionAttribute("Overrides default output directory")
                                                                       , new CategoryAttribute("Code Generation")
                                                                       , new TypeConverterAttribute(typeof(ProjectDirectoryTypeConverter))
                                                                      }));
            }
         }

         // Return the property descriptors for this element  
         return propertyDescriptors;
      }
   }
}
