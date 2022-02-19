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
         if (ModelElement is ModelDiagramData ModelDiagramData)
         {
            storeDomainDataDirectory = ModelDiagramData.Store.DomainDataDirectory;

            //Add the descriptors for the tracking properties 

            propertyDescriptors.Add(new TrackingPropertyDescriptor(ModelDiagramData
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

         // Return the property descriptors for this element  
         return propertyDescriptors;
      }
   }
}
