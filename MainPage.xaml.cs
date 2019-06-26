using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Base_Converter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string sTrNumberToBase = "";
        double baseTenNumber = 0;

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(500, 500);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500, 500));
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            //comboBox_BaseSelection items

            /* Click to expand */{
                comboBox_BaseSelection.Items.Add("Base 2");
                comboBox_BaseSelection.Items.Add("Base 3");
                comboBox_BaseSelection.Items.Add("Base 4");
                comboBox_BaseSelection.Items.Add("Base 5");
                comboBox_BaseSelection.Items.Add("Base 6");
                comboBox_BaseSelection.Items.Add("Base 7");
                comboBox_BaseSelection.Items.Add("Base 8");
                comboBox_BaseSelection.Items.Add("Base 9");
                comboBox_BaseSelection.Items.Add("Base 10");
                comboBox_BaseSelection.Items.Add("Base 11");
                comboBox_BaseSelection.Items.Add("Base 12");
                comboBox_BaseSelection.Items.Add("Base 13");
                comboBox_BaseSelection.Items.Add("Base 14");
                comboBox_BaseSelection.Items.Add("Base 15");
                comboBox_BaseSelection.Items.Add("Base 16");
                comboBox_BaseSelection.Items.Add("Floating Point");
                comboBox_BaseSelection.Items.Add("BCD");
                comboBox_BaseSelection.Items.Add("8 Bit");
            }

            //This contains the comboBox_BaseToConvertSelection items.
            /* Click to expand */{
                comboBox_BaseToConvertSelection.Items.Add("Base 2");
                comboBox_BaseToConvertSelection.Items.Add("Base 3");
                comboBox_BaseToConvertSelection.Items.Add("Base 4");
                comboBox_BaseToConvertSelection.Items.Add("Base 5");
                comboBox_BaseToConvertSelection.Items.Add("Base 6");
                comboBox_BaseToConvertSelection.Items.Add("Base 7");
                comboBox_BaseToConvertSelection.Items.Add("Base 8");
                comboBox_BaseToConvertSelection.Items.Add("Base 9");
                comboBox_BaseToConvertSelection.Items.Add("Base 10");
                comboBox_BaseToConvertSelection.Items.Add("Base 11");
                comboBox_BaseToConvertSelection.Items.Add("Base 12");
                comboBox_BaseToConvertSelection.Items.Add("Base 13");
                comboBox_BaseToConvertSelection.Items.Add("Base 14");
                comboBox_BaseToConvertSelection.Items.Add("Base 15");
                comboBox_BaseToConvertSelection.Items.Add("Base 16");
                comboBox_BaseToConvertSelection.Items.Add("Floating Point");
                comboBox_BaseToConvertSelection.Items.Add("BCD");
                comboBox_BaseToConvertSelection.Items.Add("8 Bit");

            }
        }

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectedBaseFromComboBox=0;
            dynamic selectedBaseToConvertTheNumberFromComboBox = 0;
            string userValidString = "";
            txt_NumberToConvert.Text.ToUpper();

            //The Following area contains the logic that will set the base of the number to convert and the base of the result.
            /*Click To Expand*/{

                //The base of the number

                if (comboBox_BaseSelection.SelectedIndex < 15)  
                    selectedBaseFromComboBox = 2 + comboBox_BaseSelection.SelectedIndex;


                else
                {
                    switch (comboBox_BaseSelection.SelectedIndex)
                    {
                        case 15: //Floating Point
                            selectedBaseFromComboBox = "Floating Point";
                            break;
                        case 16: //BCD
                            selectedBaseFromComboBox = "BCD";
                            break;
                        case 17: //8 Bit
                            selectedBaseFromComboBox = "8 bit";
                            break;
                    }
                }

                //The base of the result

                if (comboBox_BaseToConvertSelection.SelectedIndex < 15)
                {
                   selectedBaseToConvertTheNumberFromComboBox = 2 + comboBox_BaseToConvertSelection.SelectedIndex;
                }

                else
                {
                    switch (comboBox_BaseToConvertSelection.SelectedIndex)
                    {
                        case 15: //Floating Point
                            selectedBaseToConvertTheNumberFromComboBox = "Floating Point";
                            break;
                        case 16: //BCD
                            selectedBaseToConvertTheNumberFromComboBox = "BCD";
                            break;
                        case 17: //8 Bit
                            selectedBaseToConvertTheNumberFromComboBox = "8 bit";
                            break;
                    }
                }
            }


            //This for will add every number character to a new string and then check if the string is a valid one.
            foreach (char c in txt_NumberToConvert.Text)
            {
                if ((c >= 48 && c <= 57)|| c=='.' || (c>=65 && c<=70))
                    userValidString += c;
            }
            foreach (char c in userValidString)
            {
                if (c!='.')
                switch (selectedBaseFromComboBox)
                {
                    case 2: case 3: case 4: case 5: case 6: case 7: case 8: case 9: case 10:
                        if (c == 'A' || c == 'B' || c == 'C' || c == 'D' || c == 'E' || c == 'F')
                            userValidString = "";
                        else if (Byte.Parse(c.ToString()) >= selectedBaseFromComboBox)
                            userValidString = "";
                        break;
                    case 11: if (c == 'B' || c == 'C' || c == 'D' || c == 'E' || c == 'F') userValidString = ""; break;
                    case 12: if (c == 'C' || c == 'D' || c == 'E' || c == 'F') userValidString = ""; break;
                    case 13: if (c == 'D' || c == 'E' || c == 'F') userValidString = ""; break;
                    case 14: if (c == 'E' || c == 'F') userValidString = ""; break;
                    case 15: if (c == 'F') userValidString = ""; break;
                    default: break;
                }
            }

            
            //Will send an error message if the string is empty.
            if (userValidString == "")
            {
                var errorMessage = new MessageDialog("Write a valid number. A valid number must have at least 1 (one) digit.\nThe digits of the number must be smaller than the number of the base.\n"+
                    "Example: If the base is 3, the biggest digit for the number must be 2.");
                errorMessage.Title = "Error";
                errorMessage.Options = MessageDialogOptions.AcceptUserInputAfterDelay;
                
                errorMessage.ShowAsync();
            }
 
            else
            {
                baseTenNumber = toBaseTenFromBaseTwoToHex(userValidString, selectedBaseFromComboBox);
                if (selectedBaseToConvertTheNumberFromComboBox != 10)
                {
                    sTrNumberToBase = "";
                    convertFromBaseTenToBaseTwoToHex(baseTenNumber, selectedBaseToConvertTheNumberFromComboBox);
                    string sTrBase = "";
                    for (int i = sTrNumberToBase.Length - 1; i > -1; i--)
                        sTrBase += sTrNumberToBase[i];
                    txt_Result.Text = sTrBase;
                }
                else
                {
                    txt_Result.Text = baseTenNumber.ToString();
                }
                

            }
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            comboBox_BaseSelection.SelectedIndex = -1;
            comboBox_BaseToConvertSelection.SelectedIndex = -1;
            txt_NumberToConvert.Text = "";
            txt_Result.Text = "";
        }

        private void convertFromBaseTenToBaseTwoToHex(double number,int baseNumber)
        {
            byte module = 0;
            do
            {
                module =(byte)(number % baseNumber);
                switch (module)
                {
                    case 10:
                        sTrNumberToBase += 'A';
                        break;

                    case 11:
                        sTrNumberToBase += 'B';
                        break;

                    case 12:
                        sTrNumberToBase += 'C';
                        break;

                    case 13:
                        sTrNumberToBase += 'D';
                        break;

                    case 14:
                        sTrNumberToBase += 'E';
                        break;

                    case 15:
                        sTrNumberToBase += 'F';
                        break;

                    default:
                        sTrNumberToBase += (number % baseNumber).ToString();
                        break;

                }
            
                number -= (number % baseNumber);
                number /= baseNumber;

            } while (number != 0);
        }

        private double toBaseTenFromBaseTwoToHex(string textNumber,int baseNumber)
        {
            string notDecimal="",fractionPart= "";
            double number = 0.0;
            byte exponentControl = 0;
            bool isDecimal = false;

            for (int i = 0; i < textNumber.Length; i++)
            {
                if (textNumber[i] == '.')
                    isDecimal = true;

                if (!isDecimal)
                    notDecimal += textNumber[i];
                else if (textNumber[i]!='.' && isDecimal)
                    fractionPart += textNumber[i];
               
            }
            for (int i = notDecimal.Length-1; i > -1; i--)
            { 
                switch (notDecimal[i])
                {
                    case 'A':   number += (10 * Math.Pow(baseNumber, exponentControl)); break;
                    case 'B':   number += (11 * Math.Pow(baseNumber, exponentControl)); break;
                    case 'C':   number += (12 * Math.Pow(baseNumber, exponentControl)); break;
                    case 'D':   number += (13 * Math.Pow(baseNumber, exponentControl)); break;
                    case 'E':   number += (14 * Math.Pow(baseNumber, exponentControl)); break;
                    case 'F':   number += (15 * Math.Pow(baseNumber, exponentControl)); break;
                    default:    number += ((Double.Parse(notDecimal[i].ToString())) * (Math.Pow(baseNumber, exponentControl))); break;
                }               
                exponentControl++;
            }
            exponentControl = 1;
            for (int i= 0;i<fractionPart.Length ; i++)
            {
                number += ((1/Math.Pow(baseNumber,exponentControl))*(Double.Parse(fractionPart[i].ToString()))) ;
                exponentControl++;
            }
            
            
            return number;
        }

    }
}
