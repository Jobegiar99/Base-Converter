﻿using System;
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
        bool isNegative;

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

            isNegative = ((txt_NumberToConvert.Text[0] == '-') ? true : false);

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
                            selectedBaseToConvertTheNumberFromComboBox = 'F';
                            break;
                        case 16: //BCD
                            selectedBaseToConvertTheNumberFromComboBox = 'B';
                            break;
                        case 17: //8 Bit
                            selectedBaseToConvertTheNumberFromComboBox = '8';
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
                switch (selectedBaseToConvertTheNumberFromComboBox)
                {
                    case 2: case 3: case 4: case 5: case 6: case 7: case 8: case 9: case 10: case 11: case 12: case 13:
                    case 14: case 15: case 16:
                        baseTenNumber = toBaseTenFromBaseTwoToHex(userValidString, selectedBaseFromComboBox);
                        if (selectedBaseToConvertTheNumberFromComboBox != 10)
                        {
                            sTrNumberToBase = "";
                            convertFromBaseTenToBaseTwoToHex(baseTenNumber, selectedBaseToConvertTheNumberFromComboBox);
                            string sTrBase = ReverseString(sTrNumberToBase);
                            txt_Result.Text = sTrBase;
                        }
                        else
                        {
                            txt_Result.Text = baseTenNumber.ToString();
                        }
                        break;




                    case 'F':
                            if (selectedBaseFromComboBox != 10)
                            {
                                string stringToParse = "";
                                bool found = false;
                                for (int i = 0; i < userValidString.Length && !found; i++)
                                {
                                    if (userValidString[i] == '.')
                                        found = true;
                                    if (!found)
                                        stringToParse += userValidString[i];
                                }



                                txt_Result.Text = toFloatingPoint((toBaseTenFromBaseTwoToHex(stringToParse, selectedBaseFromComboBox)).ToString());
                            }
                            else
                            {
                                txt_Result.Text = toFloatingPoint(userValidString);
                            }
                        break;
                    case 'B':
                        txt_Result.Text = toBCD(userValidString);
                        break;
                    case '8':
                        txt_Result.Text = to8Bit(userValidString);
                        break;
                        
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
          /*  I'll fix this later.
           *  for (int i= 0;i<fractionPart.Length ; i++)
            {
                number += ((1/Math.Pow(baseNumber,exponentControl))*(Double.Parse(fractionPart[i].ToString()))) ;
                exponentControl++;
            }*/
            
            
            return number;
        }

        private string toFloatingPoint(string number)
        {
            sTrNumberToBase = "";
            long exponent = 0;
            string Mantisa = "";
            string numberWithoutDot = "";
            if (number.IndexOf('.') == -1) {
                exponent = (byte)number.Length;
                //uses sTrNumberToBase;;
                convertFromBaseTenToBaseTwoToHex(Double.Parse(number), 2);
            }
            else
            {
                bool dotFound = false;
                foreach (char c in number)
                {
                    if (c != '.') numberWithoutDot += c;
                    else dotFound = true;
                    if (!dotFound) exponent++;
                    
                }
                convertFromBaseTenToBaseTwoToHex(Double.Parse(numberWithoutDot), 2);
            }
            Mantisa = ReverseString(sTrNumberToBase);
            if (Mantisa.Length < 13)
                for (int i = Mantisa.Length; i < 12; i++)
                {
                    Mantisa += '0';
                }
            sTrNumberToBase = "";
            convertFromBaseTenToBaseTwoToHex((64 + exponent), 2);
            

            return (((isNegative) ? '1' : '0') + " " +ReverseString(sTrNumberToBase)+ " " + Mantisa);
            

        }

        private string toBCD(string numberToConvert)
        {
            string newNumber = "";
            string[] binaryNumbers = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001" };
            foreach (char c in numberToConvert)
            {
                if (c != '.')
                    newNumber += binaryNumbers[Byte.Parse(c.ToString())] + " ";
                else
                    newNumber += '.';
            }
            return newNumber;
        }

        private string to8Bit(string numberToConvert)
        {
            string newNumber = "";
            int number = Int32.Parse(numberToConvert);
            while (number > 0)
            {
                newNumber += (number % 2).ToString();
                number -= (number % 2);
                number /= 2;
            }
            if (newNumber.Length < 7)
            {
                while (newNumber.Length < 7)
                {
                    newNumber += '0';
                }
            }
            newNumber += (isNegative) ? '1' : '0';
            newNumber = ReverseString(newNumber);
            return newNumber;
        }

        private string fromBCDToAnotherBase(string number) {
            string newNumber = "";

            

            return newNumber;
        }

        private string ReverseString(string str)
        {
            string newString = "";
            for (int i = str.Length - 1; i > -1; i--)
                newString += str[i];
            return newString;
        }

    }
}
