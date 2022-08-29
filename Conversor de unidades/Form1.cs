using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Conversor_de_unidades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        

        private void answer_Enter(object sender, EventArgs e)//borra el cero a la izquierda que no tiene valor
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }

        }
        private void Invertir_texto(ComboBox comb, ComboBox comb1) 
        {
            string aux;
            aux = comb.Text;
            comb.Text = comb1.Text;
            comb1.Text = aux;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Invertir_texto(comboBox1,comboBox2);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Invertir_texto(comboBox3, comboBox4);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Invertir_texto(comboBox5, comboBox6);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Invertir_texto(comboBox7, comboBox8);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Invertir_texto(comboBox9, comboBox10);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Invertir_texto(comboBox11, comboBox12);
        }
        private void timer1_Tick(object sender, EventArgs e)//permite calcular mientras se escribe
        {
            Temperatura();
            Longitud();
            Masa();
            Velocidad();
            Volumen();
            Area();
        }


        //TEMPERATURA:

        private void Temperatura(object sender, EventArgs e)
        {
             Temperatura();
        }

        private void Temperatura()
        {
            float temp = 0;//0celsius, 1Fahrenheit, 2Kelvin
            switch (comboBox1.SelectedIndex)
            {
                case 2: if (numericUpDown1.Value < 0) numericUpDown1.Value=0; temp = Kelvin((float)numericUpDown1.Value); break;
                case 1: temp = Fahrenheit((float)numericUpDown1.Value); break;
                case 0: if (numericUpDown1.Value < -273) numericUpDown1.Value = -273; temp = Celsius((float)numericUpDown1.Value); break;
                default: temp = (float)numericUpDown1.Value; break;
            }
            if ((temp > Math.Pow(10, -(float)Decimales.Value ))||temp<=0) label2.Text = temp.ToString("F" + Decimales.Value.ToString());
            else label2.Text = temp.ToString("E" + Decimales.Value.ToString());
            
        }

        private float Kelvin(float K)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 2: return K;//0celsius, 1Fahrenheit, 2Kelvin
                case 1: return (K - 273) * 9/5+32; 
                case 0: return K - 273;
                default: return K;
            }  
        }
        private float Fahrenheit(float f)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 2: return (f - 32) * 5 / 9 + 273; //0celsius, 1Fahrenheit, 2Kelvin
                case 1: return f;
                case 0: return (f - 32) * 5/9;
                default: return f;
            }
        }
        private float Celsius(float c)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 2: return c + 273;//0celsius, 1Fahrenheit, 2Kelvin
                case 1: return (c*9/5)+32;
                case 0: return c;
                default: return c;
            }
        }




        //LONGITUD:
        
        private void Longitud(object sender, EventArgs e)
        {
            Longitud();
        }
        

        private void Longitud()
        {
            float longit = 0; 
            switch (comboBox4.SelectedIndex)
            {
                case 0: longit = Milímetro((float)numericUpDown2.Value); break;
                case 1: longit = centimetro((float)numericUpDown2.Value); break; //0Milímetros,1centímetros,2metros,3kilómetros,4pulgadas,5pies,6yardas,7millas
                case 2: longit = metro((float)numericUpDown2.Value); break;
                case 3: longit = kilómetro((float)numericUpDown2.Value); break;
                case 4: longit = pulgada((float)numericUpDown2.Value); break;
                case 5: longit = pies((float)numericUpDown2.Value); break;
                case 6: longit = yarda((float)numericUpDown2.Value); break;
                case 7: longit = milla((float)numericUpDown2.Value); break;
                default: longit = (float)numericUpDown2.Value; break;
            }//Si el valor es mayor que la cantidad de decimales, redondear al numero de decimales, sino  mostrar el exponente en base 10 
            if (longit > Math.Pow(10, -(float)Decimales.Value) || longit == 0) label7.Text = longit.ToString("F" + Decimales.Value.ToString());
            else label7.Text = longit.ToString("E" + Decimales.Value.ToString());
        }

        private float Milímetro(float mi)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: return mi;
                case 1: return mi/10;//0Milímetros,1centímetros,2metros,3kilómetros,4pulgadas,5pies,6yardas,7millas
                case 2: return mi / 1000;
                case 3: return mi / 1000000;
                case 4: return mi / (float)25.4;
                case 5: return mi / 1000 / (float)0.3048;
                case 6: return mi / 1000 / (float)0.9144;
                case 7: return mi / 1000000 / (float)1.60934;
                default: return mi;
            }
        }
        private float centimetro(float c)
        {//lsflkajs
            switch (comboBox3.SelectedIndex)
            {
                case 0: return c * 10;
                case 1: return c;//0Milímetros,1centímetros,2metros,3kilómetros,4pulgadas,5pies,6yardas,7millas
                case 2: return c/100;
                case 3: return c/100000;
                case 4: return c/(float)2.54;
                case 5: return c / 100 / (float)0.3048;
                case 6: return c / 100 / (float)0.9144;
                case 7: return c / 100000 / (float)1.60934;
                default: return c;
            }
        }

        private float metro(float m)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: return m * 1000;
                case 1: return m * 100;//0Milímetros,1centímetros,2metros,3kilómetros,4pulgadas,5pies,6yardas,7millas
                case 2: return m ;
                case 3: return m / 1000;
                case 4: return m *100/ (float)2.54;
                case 5: return m  / (float)0.3048;
                case 6: return m  / (float)0.9144;
                case 7: return m / 1000 / (float)1.60934;
                default: return m;
            }
        }

        private float kilómetro(float K)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: return K * 1000000;
                case 1: return K * 100000;//0Milímetros,1centímetros,2metros,3kilómetros,4pulgadas,5pies,6yardas,7millas
                case 2: return K * 1000;
                case 3: return K ;
                case 4: return K * 100000 / (float)2.54;
                case 5: return K * 1000 / (float)0.3048;
                case 6: return K * 1000 / (float)0.9144;
                case 7: return K / (float)1.60934;
                default: return K;
            }
        }

        private float pulgada(float p)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: return p * (float)25.4;
                case 1: return p * (float)2.54;//0Milímetros,1centímetros,2metros,3kilómetros,4pulgadas,5pies,6yardas,7millas
                case 2: return p / 100*(float)2.54;
                case 3: return p * (float)2.54 / 100000;
                case 4: return p ;
                case 5: return p  / 12;
                case 6: return p /36;
                case 7: return p /63360;
                default: return p;
            }
        }

        private float pies(float pi)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: return pi * (float)304.8;
                case 1: return pi * (float)30.48;//0Milímetros,1centímetros,2metros,3kilómetros,4pulgadas,5pies,6yardas,7millas
                case 2: return pi / 100 * (float)30.48;
                case 3: return pi * (float)30.48 / 100000;
                case 4: return pi*12;
                case 5: return pi;
                case 6: return pi /3;
                case 7: return pi / 5280;
                default: return pi;
            }
        }

        private float yarda(float y)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: return y * (float)914.4;
                case 1: return y * (float)91.44;//0Milímetros,1centímetros,2metros,3kilómetros,4pulgadas,5pies,6yardas,7millas
                case 2: return y * (float)0.9144;
                case 3: return y * (float)0.9144 / 1000;
                case 4: return y * 36;
                case 5: return y*3;
                case 6: return y;
                case 7: return y / 1760;
                default: return y;
            }
        }

        private float milla(float mi)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: return mi * 1609344;
                case 1: return mi * (float)160934.4;//0Milímetros,1centímetros,2metros,3kilómetros,4pulgadas,5pies,6yardas,7millas
                case 2: return mi * (float)1609.344;
                case 3: return mi * (float)1.609344;
                case 4: return mi * 63360;
                case 5: return mi * 5280;
                case 6: return mi * 1760;
                case 7: return mi;
                default: return mi;
            }
        }

       
        //MASA
        private void Masas(object sender, EventArgs e)
        {
            Masa();
        }

        private void Masa()
        {
            float masa = 0;
            switch (comboBox6.SelectedIndex)
            {
                case 0: masa = Miligramo((float)numericUpDown3.Value); break; //0Miligramo,1Gramo,2Kilogramo,3Tonelada,4Grano,5Dracma,6Onza,7Libra
                case 1: masa = Gramo((float)numericUpDown3.Value); break;
                case 2: masa = Kilogramo((float)numericUpDown3.Value); break;
                case 3: masa = Tonelada((float)numericUpDown3.Value); break;
                case 4: masa = Grano((float)numericUpDown3.Value); break;
                case 5: masa = Dracma((float)numericUpDown3.Value); break;
                case 6: masa = Onza((float)numericUpDown3.Value); break;
                case 7: masa = Libra((float)numericUpDown3.Value); break;
                default: masa = (float)numericUpDown3.Value; break;
            }
            if (masa > Math.Pow(10, -(float)Decimales.Value) || masa == 0) label11.Text = masa.ToString("F" + Decimales.Value.ToString());
            else label11.Text = masa.ToString("E" + Decimales.Value.ToString());
        }


        private float Miligramo(float m)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0: return m ;//0Miligramo,1Gramo,2Kilogramo,3Tonelada,4Grano,5Dracma,6Onza,7Libra
                case 1: return m / 1000;
                case 2: return m / 1000000;
                case 3: return m / 1000000000;
                case 4: return m / (float)64.79891;
                case 5: return m / (float)1771.8451953125;
                case 6: return m /(float)28349.523125;
                case 7: return m / (float)453592.37;
                default: return m;
            }

        }

        private float Gramo(float Gr)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0: return Gr*1000;//0Miligramo,1Gramo,2Kilogramo,3Tonelada,4Grano,5Dracma,6Onza,7Libra
                case 1: return Gr ;
                case 2: return Gr / 1000;
                case 3: return Gr / 1000000;
                case 4: return Gr / (float) 0.06479891;
                case 5: return Gr / (float)1.7718451953125;
                case 6: return Gr / (float)28.349523125;
                case 7: return Gr /(float)453.59237;
                default: return Gr;
            }

        }


        private float Kilogramo(float kg)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0: return kg * 1000000;//0Miligramo,1Gramo,2Kilogramo,3Tonelada,4Grano,5Dracma,6Onza,7Libra
                case 1: return kg * 1000;
                case 2: return kg;
                case 3: return kg / 1000;
                case 4: return kg / (float)0.00006479891;
                case 5: return kg / (float)0.0017718451953125;
                case 6: return kg / (float)0.028349523125;
                case 7: return kg / (float)0.45359237;
                default: return kg;
            }
        }

        private float Tonelada(float T)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0: return T * 1000000000;//0Miligramo,1Gramo,2Kilogramo,3Tonelada,4Grano,5Dracma,6Onza,7Libra
                case 1: return T * 1000000;
                case 2: return T *1000;
                case 3: return T ;
                case 4: return T / (float)0.00000006479891;
                case 5: return T / (float)0.0000017718451953125;
                case 6: return T / (float)0.000028349523125;
                case 7: return T / (float)0.00045359237;
                default: return T;
            }
        }

        private float Grano(float Gn)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0: return Gn * (float)64.79891;//0Miligramo,1Gramo,2Kilogramo,3Tonelada,4Grano,5Dracma,6Onza,7Libra
                case 1: return Gn * (float)0.06479891;
                case 2: return Gn * (float)0.00006479891;
                case 3: return Gn * (float)0.00000006479891;
                case 4: return Gn ;
                case 5: return Gn * (float)0.03657142857148;
                case 6: return Gn * (float)0.0022857142857143;
                case 7: return Gn * (float)0.00014285714285714;
                default: return Gn;
            }
        }

        private float Dracma(float D)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0: return D * (float)1771.8451953125;//0Miligramo,1Gramo,2Kilogramo,3Tonelada,4Grano,5Dracma,6Onza,7Libra
                case 1: return D * (float)1.7718451953125;
                case 2: return D * (float)0.0017718451953125;
                case 3: return D * (float)0.0000017718451953125;
                case 4: return D * (float)27.34375;
                case 5: return D ;
                case 6: return D * (float)0.0625;
                case 7: return D * (float)0.00390625;
                default: return D;
            }
        }

        private float Onza(float Oz)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0: return Oz * (float)28349.523125;//0Miligramo,1Gramo,2Kilogramo,3Tonelada,4Grano,5Dracma,6Onza,7Libra
                case 1: return Oz * (float)28.349523125;
                case 2: return Oz * (float)0.028349523125;
                case 3: return Oz * (float)0.000028349523125;
                case 4: return Oz * (float)437.5;
                case 5: return Oz * 16;
                case 6: return Oz ;
                case 7: return Oz * (float)0.0625;
                default: return Oz;
            }
        }

        private float Libra(float Lb)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0: return Lb * (float)453592.37;//0Miligramo,1Gramo,2Kilogramo,3Tonelada,4Grano,5Dracma,6Onza,7Libra
                case 1: return Lb * (float)453.59237;
                case 2: return Lb * (float)0.45359237;
                case 3: return Lb * (float)0.00045359237;
                case 4: return Lb * 7000;
                case 5: return Lb * 256;
                case 6: return Lb * 16;
                case 7: return Lb ;
                default: return Lb;
            }
        }

       
        
        //VELOCIDAD

        private void Velocidad()
        {
            float Veloc = 0;
            switch (comboBox8.SelectedIndex)
            {
                case 0: Veloc = km_s((float)numericUpDown4.Value); break; //0km/s,1m/s,2km/h,3Milla por segundo,4Milla por hora,5Pie por segundo
                case 1: Veloc = m_s((float)numericUpDown4.Value); break;
                case 2: Veloc = km_h((float)numericUpDown4.Value); break;
                case 3: Veloc = Milla_por_segundo((float)numericUpDown4.Value); break;
                case 4: Veloc = Milla_por_hora((float)numericUpDown4.Value); break;
                case 5: Veloc = Pie_por_segundo((float)numericUpDown4.Value); break;
                default: Veloc = (float)numericUpDown4.Value; break;
            }
            if (Veloc > Math.Pow(10, -(float)Decimales.Value) || Veloc == 0) label15.Text = Veloc.ToString("F" + Decimales.Value.ToString());
            else label15.Text = Veloc.ToString("E" + Decimales.Value.ToString());
        }
        private float km_s(float kms)
        {
            switch (comboBox7.SelectedIndex)
            {
                case 0: return kms ;//0km/s,1m/s,2km/h,3Milla por segundo,4Milla por hora,5Pie por segundo
                case 1: return kms * 1000;
                case 2: return kms * 3600;
                case 3: return kms * (float)0.6213712;
                case 4: return kms * (float)2236.936;
                case 5: return kms * (float)3280.84;
                default: return kms;
            }
        }

        private float m_s(float ms)
        {
            switch (comboBox7.SelectedIndex)
            {
                case 0: return ms / 1000;//0km/s,1m/s,2km/h,3Milla por segundo,4Milla por hora,5Pie por segundo
                case 1: return ms ;
                case 2: return ms * (float)3.6;
                case 3: return ms * (float)0.0006213712;
                case 4: return ms * (float)2.236936;
                case 5: return ms * (float)3.28084;
                default: return ms;
            }
        }

        private float km_h(float kmh)
        {
            switch (comboBox7.SelectedIndex)
            {
                case 0: return kmh / 3600;//0km/s,1m/s,2km/h,3Milla por segundo,4Milla por hora,5Pie por segundo
                case 1: return kmh / (float)3.6;
                case 2: return kmh ;
                case 3: return kmh * (float)0.0001726031;
                case 4: return kmh * (float)0.6213711111;
                case 5: return kmh * (float)0.9113444444;
                default: return kmh;
            }
        }

        private float Milla_por_segundo(float MipS)
        {
            switch (comboBox7.SelectedIndex)
            {
                case 0: return MipS *(float)1.609344;//0km/s,1m/s,2km/h,3Milla por segundo,4Milla por hora,5Pie por segundo
                case 1: return MipS * (float)0.44704 * 3600;
                case 2: return MipS * (float)1.609344 * 3600;
                case 3: return MipS;
                case 4: return MipS * 3600;
                case 5: return MipS * (float)0.9113444444;
                default: return MipS;
            }
        }

        private float Milla_por_hora(float MPH)
        {
            switch (comboBox7.SelectedIndex)
            {
                case 0: return MPH * (float)1.609344 / 3600;//0km/s,1m/s,2km/h,3Milla por segundo,4Milla por hora,5Pie por segundo
                case 1: return MPH * (float)0.44704;
                case 2: return MPH * (float)1.609344;
                case 3: return MPH / 3600;
                case 4: return MPH ;
                case 5: return MPH * (float)1.4667;
                default: return MPH;
            }
        }

        private float Pie_por_segundo(float PPS)
        {
            switch (comboBox7.SelectedIndex)
            {
                case 0: return PPS * (float)0.0003048;//0km/s,1m/s,2km/h,3Milla por segundo,4Milla por hora,5Pie por segundo
                case 1: return PPS * (float)0.3047999902;
                case 2: return PPS * (float)1.0972799649;
                case 3: return PPS * (float)0.0001893939;
                case 4: return PPS * (float)0.681818071;
                case 5: return PPS ;
                default: return PPS;
            }
        }


        //VOLUMEN
        private void Volumen()
        {
            float Vol = 0;
            switch (comboBox10.SelectedIndex)
            {
                case 0: Vol = litro((float)numericUpDown5.Value) * 1000; break; //0m³,1hl,2Decalitro,3dm³,4Litro,5dl,6cl,7cm³,8ml,9mm³,10Barril,11Medida de áridos,12Picotazo,13Galón,14Cuarto de galón,15Pinta,16Onza líquida
                case 1: Vol = litro((float)numericUpDown5.Value) * 100; break;
                case 2: Vol = litro((int)numericUpDown5.Value)*10; break;
                case 3:
                case 4: Vol = litro((float)numericUpDown5.Value); break;
                case 5: Vol = litro((float)numericUpDown5.Value) / 10; break;
                case 6: Vol = litro((float)numericUpDown5.Value) / 100; break;
                case 7:
                case 8: Vol = litro((float)numericUpDown5.Value) / 1000; break;
                case 9: Vol = litro((float)numericUpDown5.Value) / 1000000; break;
                case 10: Vol = Galón((float)numericUpDown5.Value) / (float)0.0278; break;
                case 11: Vol = Galón((float)numericUpDown5.Value) * 8; break;
                case 12: Vol = Galón((float)numericUpDown5.Value) * 2; break;
                case 13: Vol = Galón((float)numericUpDown5.Value); break;
                case 14: Vol = Galón((float)numericUpDown5.Value) / 4; break;
                case 15: Vol = Galón((float)numericUpDown5.Value) / 8; break;
                case 16: Vol = Galón((float)numericUpDown5.Value) / 160; break;
                default: Vol = (float)numericUpDown5.Value; break;
            }
            if (Vol > Math.Pow(10, -(float)Decimales.Value) || Vol == 0) label19.Text = Vol.ToString("F" + Decimales.Value.ToString());
            else label19.Text = Vol.ToString("E" + Decimales.Value.ToString());
        }

        private float litro(float l)
        {
            switch (comboBox9.SelectedIndex)
            {
                case 0: return l / 1000;//0m³,1hl,2Decalitro,3dm³,4Litro,5dl,6cl,7cm³,8ml,9mm³,10Barril,11Medida de áridos,12Picotazo,13Galón,14Cuarto de galón,15Pinta,16Onza líquida
                case 1: return l / 100;
                case 2: return l / 10;
                case 3: 
                case 4: return l;
                case 5: return l * 10;
                case 6: return l * 100;
                case 7: 
                case 8: return l * 1000;
                case 9: return l * 1000000;
                case 10: return l * (float)0.006110602;
                case 11: return l * (float)0.0274961;
                case 12: return l * (float)0.1099844;
                case 13: return l * (float)0.2199688;
                case 14: return l * (float)0.8798751;
                case 15: return l * (float)1.759751;
                case 16: return l * (float)35.19501;
                default: return l;
            }
        }

        private float Galón(float G)
        {
            switch (comboBox9.SelectedIndex)
            {
                case 0: return G * (float)4.5461/ 1000;//0m³,1hl,2Decalitro,3dm³,4Litro,5dl,6cl,7cm³,8ml,9mm³,10Barril,11Medida de áridos,12Picotazo,13Galón,14Cuarto de galón,15Pinta,16Onza líquida
                case 1: return G * (float)4.5461 / 100;
                case 2: return G * (float)4.5461 / 10;
                case 3:
                case 4: return G * (float)4.5461;
                case 5: return G * 10 * (float)4.5461;
                case 6: return G * 100 * (float)4.5461;
                case 7:
                case 8: return G * 1000 * (float)4.5461;
                case 9: return G * 1000000 * (float)4.5461;
                case 10: return G * (float)0.0278;
                case 11: return G /8;
                case 12: return G /2;
                case 13: return G ;
                case 14: return G * 4;
                case 15: return G * 8;
                case 16: return G * 160;
                default: return G;
            }
        }


        //AREA
        private void Area()
        {
            float area = 0;
            switch (comboBox12.SelectedIndex)
            {
                case 0: area = metro2((float)numericUpDown6.Value) * 1000000; break; //0km²,1Hectárea,2Área,3m²,4dm²,5cm²,6mm²,7Municipio,8Milla²,9Patrimonio familiar,10Acre,11Rood,12Rod cuadrada,13Cuadrado,14Yarda cuadrada,15Pie cuadrado,16Pulgada cuadrada
                case 1: area = metro2((float)numericUpDown6.Value) * 10000; break;
                case 2: area = metro2((float)numericUpDown6.Value) * 100; break;
                case 3: area = metro2((float)numericUpDown6.Value); break;
                case 4: area = metro2((float)numericUpDown6.Value) / 100; break;
                case 5: area = metro2((float)numericUpDown6.Value) / 10000; break;
                case 6: area = metro2((float)numericUpDown6.Value) / 1000000; break;
                case 7: area = Milla2((float)numericUpDown6.Value) / (float)0.0278; break;
                case 8: area = Milla2((float)numericUpDown6.Value); break;
                case 9: area = Milla2((float)numericUpDown6.Value) / 4; break;
                case 10: area = Milla2((float)numericUpDown6.Value) / 640; break;
                case 11: area = Milla2((float)numericUpDown6.Value) / 2560; break;
                case 12: area = Milla2((float)numericUpDown6.Value) / 102400; break;
                case 13: area = Milla2((float)numericUpDown6.Value) / 278784; break;
                case 14: area = Milla2((float)numericUpDown6.Value) / 3097600; break;
                case 15: area = Milla2((float)numericUpDown6.Value) / 27878400; break;
                case 16: area = Milla2((float)numericUpDown6.Value) / 4014489600; break;
                default: area = (float)numericUpDown5.Value; break;
            }
            if (area > Math.Pow(10, -(float)Decimales.Value) || area == 0) label23.Text = area.ToString("F" + Decimales.Value.ToString());
            else label23.Text = area.ToString("E"+Decimales.Value.ToString());
        }

        private float metro2(float m2)
        {
            switch (comboBox11.SelectedIndex)
            {
                case 0: return m2 / 1000000; //0km²,1Hectárea,2Área,3m²,4dm²,5cm²,6mm²,7Municipio,8Milla²,9Patrimonio familiar,10Acre,11Rood,12Rod cuadrada,13Cuadrado,14Yarda cuadrada,15Pie cuadrado,16Pulgada cuadrada
                case 1: return m2 / 10000;
                case 2: return m2 / 100;
                case 3: return m2;
                case 4: return m2 * 100;
                case 5: return m2 * 10000;
                case 6: return m2 * 1000000;
                case 7: return m2 * (float)1.07251 / 100000000;
                case 8: return m2 * (float)3.861022 / 10000000;
                case 9: return m2 * (float)0.0000015444;
                case 10: return m2 * (float)0.0002471055;
                case 11: return m2 * (float)0.000988422;
                case 12: return m2 * (float)0.03953687;
                case 13: return m2 * (float)0.1076391;
                case 14: return m2 * (float)1.19599;
                case 15: return m2 * (float)10.76391;
                case 16: return m2 * (float)1550.003;
                default: return m2;
            }
        }


        private float Milla2(float Mi2)
        {
            switch (comboBox11.SelectedIndex)
            {
                case 0: return Mi2 * (float)2589987.832 / 1000000; //0km²,1Hectárea,2Área,3m²,4dm²,5cm²,6mm²,7Municipio,8Milla²,9Patrimonio familiar,10Acre,11Rood,12Rod cuadrada,13Cuadrado,14Yarda cuadrada,15Pie cuadrado,16Pulgada cuadrada
                case 1: return Mi2 *(float)2589987.832/ 10000;
                case 2: return Mi2 *(float)2589987.832/ 100;
                case 3: return Mi2 *(float)2589987.832;
                case 4: return Mi2 * 100 *(float)2589987.832;
                case 5: return Mi2 * 10000 *(float)2589987.832;
                case 6: return Mi2 * 1000000 *(float)2589987.832;
                case 7: return Mi2 * (float)0.0278;
                case 8: return Mi2 ;
                case 9: return Mi2 * 4;
                case 10: return Mi2 * 640;
                case 11: return Mi2 * 2560;
                case 12: return Mi2 * 102400;
                case 13: return Mi2 * 278784;
                case 14: return Mi2 * 3097600;
                case 15: return Mi2 * 27878400;
                case 16: return Mi2 * 4014489600;
                default: return Mi2;
            }
        }

        
    }
}
