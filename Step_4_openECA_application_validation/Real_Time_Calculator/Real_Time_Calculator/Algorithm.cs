using System;
using System.Numerics;
using ECAClientFramework;
using Real_Time_Calculator.Model.VT;

namespace Real_Time_Calculator
{
    static class Algorithm
    {
        public static void UpdateSystemSettings()
        {
            SystemSettings.ConnectionString = @"server=localhost:6190; interface=0.0.0.0";
            SystemSettings.FramesPerSecond = 30;
            SystemSettings.LagTime = 3;
            SystemSettings.LeadTime = 1;
        }

        public static Line_parameters Execute(VI_pair input)
        {
            Line_parameters output = new Line_parameters();

            try
            {
                double V1_mag = input.From_bus_Voltage_Mag;
                double V1_ang = input.From_bus_Voltage_Ang;
                double I1_mag = input.From_bus_Current_Mag;
                double I1_ang = input.From_bus_Current_Ang;

                double V1_Real = V1_mag * Math.Cos(V1_ang * Math.PI / 180);
                double V1_Imag = V1_mag * Math.Sin(V1_ang * Math.PI / 180);
                double I1_Real = I1_mag * Math.Cos(I1_ang * Math.PI / 180);
                double I1_Imag = I1_mag * Math.Sin(I1_ang * Math.PI / 180);
                Complex V1 = new Complex(V1_Real, V1_Imag);
                Complex I1 = new Complex(I1_Real, I1_Imag);

                double V2_mag = input.To_bus_Voltage_Mag;
                double V2_ang = input.To_bus_Voltage_Ang;
                double I2_mag = input.To_bus_Current_Mag;
                double I2_ang = input.To_bus_Current_Ang;

                double V2_Real = V2_mag * Math.Cos(V2_ang * Math.PI / 180);
                double V2_Imag = V2_mag * Math.Sin(V2_ang * Math.PI / 180);
                double I2_Real = I2_mag * Math.Cos(I2_ang * Math.PI / 180);
                double I2_Imag = I2_mag * Math.Sin(I2_ang * Math.PI / 180);
                Complex V2 = new Complex(V2_Real, V2_Imag);
                Complex I2 = new Complex(I2_Real, I2_Imag);

                Complex Line_impedance_cplx = (V1 * V1 - V2 * V2) / (I2 * V2 - I1 * V1);
                Complex Susceptance_cplx = (I1 + I2) / (V1 + V2);

                double line_impedance_Real = Line_impedance_cplx.Real;
                double line_impedance_Imag = Line_impedance_cplx.Imaginary;
                double Susceptance = Susceptance_cplx.Imaginary;

                output.Impedance_Real = line_impedance_Real;
                output.Impedance_Imag = line_impedance_Imag;
                output.Susceptance = Susceptance;

                String message_to_show_impedance = "Impedance: " + line_impedance_Real.ToString() + " + " + line_impedance_Imag.ToString() + "i";
                MainWindow.WriteMessage(message_to_show_impedance);

                String message_to_show_susceptance = "Susceptance: " + Susceptance.ToString() + "i";
                MainWindow.WriteMessage(message_to_show_susceptance);
            }
            catch (Exception ex)
            {
                // Display exceptions to the main window
                MainWindow.WriteError(new InvalidOperationException($"Algorithm exception: {ex.Message}", ex));
            }

            return output;
        }
    }
}
