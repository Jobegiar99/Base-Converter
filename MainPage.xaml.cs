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
            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = "";
            /* ApplicationView.PreferredLaunchViewSize = new Size(500, 500);
             ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
             ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500, 500));
             ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;*/

            //comboBox_BaseSelection items

            /* Click to expand */
            {
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
            txt_NumberToConvert.Text=txt_NumberToConvert.Text.ToUpper();
            if (comboBox_BaseSelection.SelectedIndex == -1 || comboBox_BaseToConvertSelection.SelectedIndex == -1)
            {
                txt_Result.Text = "You need to select both bases";
            }
            else
            {
                dynamic selectedBaseFromComboBox = 0;
                dynamic selectedBaseToConvertTheNumberFromComboBox = 0;
                string userValidString = "";
                sTrNumberToBase = "";
                txt_Result.Text = "";

                isNegative = ((txt_NumberToConvert.Text[0] == '-') ? true : false);

                txt_NumberToConvert.Text.ToUpper();

                //The Following area contains the logic that will set the base of the number to convert and the base of the result.
                /*Click To Expand*/
                {

                    //The base of the number

                    if (comboBox_BaseSelection.SelectedIndex < 15)
                        selectedBaseFromComboBox = 2 + comboBox_BaseSelection.SelectedIndex;


                    else
                    {
                        switch (comboBox_BaseSelection.SelectedIndex)
                        {

                            case 15: //BCD
                                selectedBaseFromComboBox = 'B';
                                break;
                            case 16: //8 Bit
                                selectedBaseFromComboBox = '8';
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
                    if ((c >= 48 && c <= 57) || c == '.' || (c >= 65 && c <= 70))
                        userValidString += c;
                }
                userValidString.ToUpper();

                foreach (char c in userValidString)
                {
                    if (c != '.')
                        switch (selectedBaseFromComboBox)
                        {
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
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
                            default:
                                break;
                        }
                }


                //Will send an error message if the string is empty.
                if (userValidString == "")
                {
                    txt_Result.Text = "Write a valid number";
                }

                else
                {
                    if (selectedBaseFromComboBox == 'F' || selectedBaseFromComboBox == 'B' || selectedBaseFromComboBox == '8')
                    {
                        switch (selectedBaseFromComboBox)
                        {
                            case 'F':

                                break;
                            case 'B':
                                txt_Result.Text = FromBCDToAnotherBase(userValidString, selectedBaseToConvertTheNumberFromComboBox);
                                break;
                            case '8':
                                txt_Result.Text = From8BitToAnotherBase(userValidString, selectedBaseToConvertTheNumberFromComboBox);
                                break;
                        }
                    }
                    else
                    {
                        switch (selectedBaseToConvertTheNumberFromComboBox)
                        {
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                                baseTenNumber = ToBaseTenFromBaseTwoToHex(userValidString, selectedBaseFromComboBox);
                                if (selectedBaseToConvertTheNumberFromComboBox != 10)
                                {
                                    sTrNumberToBase = "";
                                    ConvertFromBaseTenToBaseTwoToHex(baseTenNumber, selectedBaseToConvertTheNumberFromComboBox);
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



                                    txt_Result.Text = ToFloatingPoint((ToBaseTenFromBaseTwoToHex(stringToParse, selectedBaseFromComboBox)).ToString());
                                }
                                else
                                {
                                    txt_Result.Text = ToFloatingPoint(userValidString);
                                }
                                break;
                            case 'B':
                              
                                txt_Result.Text = ToBCD(userValidString);
                                break;
                            case '8':
                                if (selectedBaseFromComboBox != 10)
                                {
                                    userValidString = (ToBaseTenFromBaseTwoToHex(userValidString, selectedBaseFromComboBox)).ToString();
                                }
                                txt_Result.Text = To8Bit(userValidString);
                                break;

                        }
                    }
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


        /// <summary>
        /// Convert any base 10 number to another base from 2 to 16.
        /// </summary>
        /// <param name="number">the base 10 number.</param>
        /// <param name="baseNumber">the base desired to convert the base 10 number</param>
        private void ConvertFromBaseTenToBaseTwoToHex(double number,int baseNumber)
        {
         
            byte module = 0;
            do
            {
                module = (byte)(number % baseNumber);
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



        /// <summary>
        /// returns a base 10 representation of any base from base 2 to base 16.
        /// </summary>
        /// <param name="textNumber">The string representation of the base number</param>
        /// <param name="baseNumber">The base of textNumber parameter.</param>
        /// <returns></returns>
        private double ToBaseTenFromBaseTwoToHex(string textNumber,int baseNumber)
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



        /// <summary>
        /// Transforms a base 10 number to its floating point representation.
        /// </summary>
        /// <param name="number"> The Base 10 number desired to be convert into floating point</param>
        /// <returns>Will return the floating point as a string</returns>
        private string ToFloatingPoint(string number)
        {
            
            sTrNumberToBase = "";
            long exponent = 0;
            string Mantisa = "";
            
            if (number.IndexOf('.') !=-1)
            {
                string newText = "";
                for (int i = 0; number[i] != '.'; i++)
                {
                    newText += number[i];
                }
                number = newText;
               
               
            }
            ConvertFromBaseTenToBaseTwoToHex(Double.Parse(number), 2);
            ReverseString(sTrNumberToBase);
            exponent = sTrNumberToBase.Length;

            Mantisa = ReverseString(sTrNumberToBase);
            if (Mantisa.Length < 13)
                for (int i = Mantisa.Length; i < 12; i++)
                {
                    Mantisa += '0';
                }
            sTrNumberToBase = "";
            ConvertFromBaseTenToBaseTwoToHex((64 + exponent), 2);
            

            return (((isNegative) ? '1' : '0') + " " +ReverseString(sTrNumberToBase)+ " " + Mantisa);
            

        }


        /// <summary>
        /// Converts any base 10 number to bcd.
        /// </summary>
        /// <param name="numberToConvert">A base 10 string desired to be converted into BCD.</param>
        /// <returns>A string representation of the BCD number</returns>
        private string ToBCD(string numberToConvert)
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

        /// <summary>
        /// This functions transform a base 10 number to its 8 bit representation
        /// </summary>
        /// <param name="numberToConvert">The base 10 string that will be transformed into its 8 bit representation</param>
        /// <returns>The string that represents the base 10 number as an 8 bit number.</returns>
        private string To8Bit(string numberToConvert)
        {
            if (numberToConvert.IndexOf('.') != -1)
            {
                numberToConvert = numberToConvert.Substring(0, numberToConvert.IndexOf('.'));
            }
            if (Int64.Parse(numberToConvert) > 127 || Int64.Parse(numberToConvert) < -127)
            {
                return "That number can't be represented with 8 bit.";
            }
            else
            {
                string newNumber = "";
                int number = Int32.Parse(numberToConvert);
                while (number > 0)
                {
                    newNumber += (number % 2).ToString();
                    number -= (number % 2);
                    number /= 2;
                }
                if (newNumber.Length < 8)
                {
                    while (newNumber.Length < 7)
                    {
                        newNumber += '0';
                    }
                }
                newNumber += (!isNegative) ? "0" : "1";
                newNumber = ReverseString(newNumber);
                return newNumber;
            }

        }



        /// <summary>
        /// Converts any BCD number to any base.
        /// </summary>
        /// <param name="BCDnumber">The string representation of the BCD number</param>
        /// <param name="selectedBaseToConvertFromBCD">The desired base to convert the BCD number</param>
        /// <returns>A string representation of the new base</returns>
        private string FromBCDToAnotherBase(string BCDnumber, dynamic selectedBaseToConvertFromBCD) {
            foreach (char c in BCDnumber)
            {
                if (c!='.')
                    if ((c != '0' && c != '1'))
                        return "Type a valid BCD Number";
            }


            string newNumber = "";
            Dictionary<string, int> map = new Dictionary<string, int>
            {
                ["0000"] = 0,
                ["0001"] = 1,
                ["0010"] = 2,
                ["0011"] = 3,
                ["0100"] = 4,
                ["0101"] = 5,
                ["0110"] = 6,
                ["0111"] = 7,
                ["1000"] = 8,
                ["1001"] = 9,

            };
            if (BCDnumber.IndexOf('.') == -1)
            {
                if (BCDnumber.Length % 4 != 0)
                {
                    return "Type a valid BCD Number";
                }
                for (int i = 0; i < BCDnumber.Length - 3; i+=4)
                {
                    try
                    {
                        newNumber += map[BCDnumber.Substring(i, 4)].ToString();
                    }
                    catch (Exception)
                    {
                        return "Type a valid BCD Number";
                    }
                }
            }
            else
            {
                if ((BCDnumber.Length - 1) % 4 != 0)
                {
                    return "Type a valid BCD Number";
                }
                int i = 0;
                while (i < BCDnumber.Length - 3)
                {
                    if (BCDnumber[i] == '.')
                    {
                        newNumber += '.';
                        i += 1;
                    }
                    else
                    {
                        try
                        {
                            newNumber += map[BCDnumber.Substring(i, 4)].ToString();
                            i += 4;
                        }
                        catch (Exception)
                        {
                            return "Type a valid BCD Number";
                        }
                        
                    }
                }
            }


            switch (selectedBaseToConvertFromBCD)
            {
                case 10:
                    break;
                case '8':
                    if (Double.Parse(newNumber) < 128 && Double.Parse(newNumber) > -128)
                    {
                        newNumber = To8Bit(newNumber);
                    }
                    else
                    {
                        return "That number can't be represented with 8 bit.";
                    }
                    break;
                case 'B':
                    newNumber = BCDnumber;
                    break;
                case 'F':
                    newNumber = ToFloatingPoint(newNumber);
                    return newNumber;
                default:
                    ConvertFromBaseTenToBaseTwoToHex(Double.Parse(newNumber), selectedBaseToConvertFromBCD);
                    newNumber = sTrNumberToBase;
                    newNumber = ReverseString(newNumber);
                    break;

                
            }
            return (newNumber[0]=='0' && newNumber[1]!='.')? newNumber.Substring(1):(newNumber[0]=='.')? "0"+newNumber: newNumber;

        }


        /// <summary>
        /// Converts any 8bit number to any base
        /// </summary>
        /// <param name="bitNumber">The string representation of the 8bit number</param>
        /// <param name="selectedBaseToConvertFrom8Bit">The desired base to convert the BCD Number</param>
        /// <returns>A string representation of the new base</returns>
        private string From8BitToAnotherBase(string bitNumber,dynamic selectedBaseToConvertFrom8Bit)
        {
            if (bitNumber.Length == 8)
            {
                bool isValid = true;
                foreach (char c in bitNumber)
                    if (c != '0' && c != '1')
                        isValid = false;
                if (isValid)
                {
                    double base10Number = 0;
                    string newBase = "";
                    for (int i = 7; i > 0; i--)
                    {
                        base10Number += (Math.Pow(2, 7 - i)) * Byte.Parse(bitNumber[i].ToString());
                    }
                    switch (selectedBaseToConvertFrom8Bit)
                    {
                        case 10:
                            newBase += ((bitNumber[0] == '0') ? "" : "-") + base10Number.ToString();
                            break;
                        case '8':
                            newBase = bitNumber;
                            break;
                        case 'F':
                            isNegative = ((bitNumber[0] == '0') ? false : true);
                            newBase = ToFloatingPoint(base10Number.ToString());
                            break;
                        case 'B':
                            newBase = ToBCD(base10Number.ToString());
                            break;
                        default:
                            ConvertFromBaseTenToBaseTwoToHex(base10Number, selectedBaseToConvertFrom8Bit);
                            newBase += ((bitNumber[0] == '0') ? "" : "-") + ReverseString(sTrNumberToBase);
                            break;
                    }

                    return newBase;
                }
            }
            return "Type a correct 8 bit number";

        }


        


        /// <summary>
        /// Reverses any string.
        /// </summary>
        /// <param name="str">The desired string to reverse</param>
        /// <returns>The reversed version of the string</returns>
        private string ReverseString(string str)
        {
            string newString = "";
            for (int i = str.Length - 1; i > -1; i--)
                newString += str[i];
            return newString;
        }

      
    }
}
