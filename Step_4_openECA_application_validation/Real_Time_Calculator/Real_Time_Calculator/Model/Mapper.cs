// COMPILER GENERATED CODE
// THIS WILL BE OVERWRITTEN AT EACH GENERATION
// EDIT AT YOUR OWN RISK

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ECAClientFramework;
using ECAClientUtilities;
using ECAClientUtilities.Model;
using GSF.TimeSeries;

namespace Real_Time_Calculator.Model
{
    [CompilerGenerated]
    public class Mapper : MapperBase
    {
        #region [ Members ]

        // Fields
        private int m_index;

        #endregion

        #region [ Constructors ]

        public Mapper(SignalLookup lookup) : base(lookup, "VI_data")
        {
        }

        #endregion

        #region [ Methods ]

        public override void Map(IDictionary<MeasurementKey, IMeasurement> measurements)
        {
            m_index = 0;
            SignalLookup.UpdateMeasurementLookup(measurements);
            TypeMapping inputMapping = MappingCompiler.GetTypeMapping(InputMapping);

            Real_Time_Calculator.Model.VT.VI_pair input = CreateVTVI_pair(inputMapping);

            Real_Time_Calculator.Model.VT.Line_parameters output = Algorithm.Execute(input);

            // TODO: Later versions will publish output to the openECA server
        }

        private Real_Time_Calculator.Model.VT.VI_pair CreateVTVI_pair(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(fieldMapping => fieldMapping.Field.Identifier);
            Real_Time_Calculator.Model.VT.VI_pair obj = new Real_Time_Calculator.Model.VT.VI_pair();

            obj.From_bus_Voltage_Mag = (double)SignalLookup.GetMeasurement(Keys[m_index++][0]).Value;

			obj.From_bus_Voltage_Ang = (double)SignalLookup.GetMeasurement(Keys[m_index++][0]).Value;

			obj.From_bus_Current_Mag = (double)SignalLookup.GetMeasurement(Keys[m_index++][0]).Value;

			obj.From_bus_Current_Ang = (double)SignalLookup.GetMeasurement(Keys[m_index++][0]).Value;

			obj.To_bus_Voltage_Mag = (double)SignalLookup.GetMeasurement(Keys[m_index++][0]).Value;

			obj.To_bus_Voltage_Ang = (double)SignalLookup.GetMeasurement(Keys[m_index++][0]).Value;

			obj.To_bus_Current_Mag = (double)SignalLookup.GetMeasurement(Keys[m_index++][0]).Value;

			obj.To_bus_Current_Ang = (double)SignalLookup.GetMeasurement(Keys[m_index++][0]).Value;

            return obj;
        }

        #endregion
    }
}
