using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalcEngineDemo
{
    class FunctionMenu : ContextMenuStrip
    {
        public FunctionMenu()
        {
            AddItems("Logical", LOGICAL);
            AddItems("Math/Trigonometry", MATH);
            AddItems("Statistical", STATISTICAL);
            AddItems("Text", TEXT);
        }
        void AddItems(string category, string functions)
        {
            var item = new ToolStripMenuItem(category);
            foreach (var fn in functions.Split('\r', '\n'))
            {
                var data = fn.Split('\t');
                if (data.Length == 3)
                {
                    var x = item.DropDownItems.Add(data[0].Trim());
                    x.ToolTipText = string.Format("{0}\r\n\r\n{1}", data[1].Trim(), data[2].Trim());
                }
            }
            item.DropDownItemClicked += (s, e) =>
                {
                    this.OnItemClicked(new ToolStripItemClickedEventArgs(e.ClickedItem));
                };
            Items.Add(item);
        }

        // function names, descriptions, and parameters (from excel sheet in Documentation folder)
        const string LOGICAL =
            @"AND	Returns TRUE if all of its arguments are TRUE	=AND(logical1[, logical2,…])
            FALSE	Returns the logical value FALSE	=FALSE
            IF	Specifies a logical test to perform	=IF(logical_test, value_if_true, value_if_false)
            NOT	Reverses the logic of its argument	=NOT(logical)
            OR	Returns TRUE if any argument is TRUE	=OR(logical1[, logical2,…])
            TRUE	Returns the logical value TRUE	=TRUE";
        const string MATH = 
            @"ABS	Returns the absolute value of a number	=ABS(number)
            ACOS	Returns the arccosine of a number	=ACOS(number)
            ASIN	Returns the arcsine of a number	=ASIN(number)
            ATAN	Returns the arctangent of a number	=ATAN(number)
            ATAN2	Returns the arctangent from x- and y-coordinates	=ATAN2(x_num, y_num)
            CEILING	Rounds a number to the nearest integer or to the nearest multiple of significance	=CEILING(number)
            COS	Returns the cosine of a number	=COS(number)
            COSH	Returns the hyperbolic cosine of a number	=COSH(number)
            EXP	Returns e raised to the power of a given number	=EXP(number)
            FLOOR	Rounds a number down, toward zero	=FLOOR(number)
            INT	Rounds a number down to the nearest integer	=INT(number)
            LN	Returns the natural logarithm of a number	=LN(number)
            LOG	Returns the logarithm of a number to a specified base	=LOG(number[, base])
            LOG10	Returns the base-10 logarithm of a number	=LOG10(number)
            PI	Returns the value of pi	=PI()
            POWER	Returns the result of a number raised to a power	=POWER(number, power)
            RAND	Returns a random number between 0 and 1	=RAND()
            RANDBETWEEN	Returns a random number between the numbers you specify	=RANDBETWEEN(bottom, top)
            SIGN	Returns the sign of a number	=SIGN(number)
            SIN	Returns the sine of the given angle	=SIN(number)
            SINH	Returns the hyperbolic sine of a number	=SINH(number)
            SQRT	Returns a positive square root	=SQRT(number)
            SUM	Adds its arguments	=SUM(number1[, number2, …])
            TAN	Returns the tangent of a number	=TAN(number)
            TANH	Returns the hyperbolic tangent of a number	=TANH(number)
            TRUNC	Truncates a number to an integer	=TRUNC(number)";
        const string STATISTICAL = 
            @"AVERAGE	Returns the average of its arguments	
            AVERAGEA	Returns the average of its arguments, including numbers, text, and logical values	=AVERAGE(number1 [, number2, …])
            COUNT	Counts how many numbers are in the list of arguments	=AVERAGEA(number1 [, number2, …])
            COUNTA	Counts how many values are in the list of arguments	=COUNT(number1 [, number2, …])
            COUNTBLANK	Counts the number of blank cells within a range	=COUNTA(number1 [, number2, …])
            COUNTIF	Counts the number of cells within a range that meet the given criteria	=COUNTIF(range, criteria)
            MAX	Returns the maximum value in a list of arguments	=MAX(number1 [, number2, …])
            MAXA	Returns the maximum value in a list of arguments, including numbers, text, and logical values	=MAXA(number1 [, number2, …])
            MIN	Returns the minimum value in a list of arguments	=MIN(number1 [, number2, …])
            MINA	Returns the smallest value in a list of arguments, including numbers, text, and logical values	=MINA(number1 [, number2, …])
            STDEV	Estimates standard deviation based on a sample	=STDEV(number1 [, number2, …])
            STDEVA	Estimates standard deviation based on a sample, including numbers, text, and logical values	=STDEVA(number1 [, number2, …])
            STDEVP	Calculates standard deviation based on the entire population	=STDEVP(number1 [, number2, …])
            STDEVPA	Calculates standard deviation based on the entire population, including numbers, text, and logical values	=STDEVPA(number1 [, number2, …])
            VAR	Estimates variance based on a sample	=VAR(number1 [, number2, …])
            VARA	Estimates variance based on a sample, including numbers, text, and logical values	=VARA(number1 [, number2, …])
            VARP	Calculates variance based on the entire population	=VARP(number1 [, number2, …])
            VARPA	Calculates variance based on the entire population, including numbers, text, and logical values	=VARPA(number1 [, number2, …])";
        const string TEXT =
            @"CHAR	Returns the character specified by the code number	=CHAR(number)
            CODE	Returns a numeric code for the first character in a text string	=CODE(text)
            CONCATENATE	Joins several text items into one text item	=CONCATENATE(text1 [, text2, …])
            FIND	Finds one text value within another (case-sensitive)	=FIND(find_text, within_text [, start_num])
            LEFT	Returns the leftmost characters from a text value	=LEFT(text[, num_chars])
            LEN	Returns the number of characters in a text string	=LEN(text)
            LOWER	Converts text to lowercase	=LOWER(text)
            MID	Returns a specific number of characters from a text string starting at the position you specify	=MID(text, start_num, num_chars)
            PROPER	Capitalizes the first letter in each word of a text value	=PROPER(text)
            REPLACE	Replaces characters within text	=REPLACE(old_text, stat_num, num_chars, new_text)
            REPT	Repeats text a given number of times	=REPT(trext, number_times)
            RIGHT	Returns the rightmost characters from a text value	=RIGHT(text[, num_chars])
            SEARCH	Finds one text value within another (not case-sensitive)	=SEARCH(find_text, within_text[, start_num])
            SUBSTITUTE	Substitutes new text for old text in a text string	=SUBSTITUTE(text, old_text, new_text[, instance_num])
            T	Converts its arguments to text	=T(value)
            TEXT	Formats a number and converts it to text	=TEXT(value, format_text)
            TRIM	Removes spaces from text	=TRIM(text)
            UPPER	Converts text to uppercase	=UPPER(text)
            VALUE	Converts a text argument to a number	=VALUE(text)";
    }
}
