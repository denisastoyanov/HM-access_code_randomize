using System;
using System.IO;


string fourDigitCodeGenerate(int digitRange, int startDigit = -1)
{
    Random rnd = new Random();
    int[] digits = new int[4];
    int repeatDigit = rnd.Next(1, digitRange);
    if (startDigit == -1)
    {
        digits[0] = repeatDigit;
        digits[1] = repeatDigit;
    }
    else
    {
        digits[0] = startDigit;
        digits[1] = startDigit;
    }
    

    for (int i = 2; i < 4; i++)
    {
        int newDigit;
        do
        {
            newDigit = rnd.Next(1, digitRange);
        } while (newDigit == repeatDigit || digits.Contains(newDigit));
        digits[i] = newDigit;
    }

    //digits = digits.OrderBy(x => rnd.Next()).ToArray();
    string result = string.Join("", digits);

    return result;
}

string m6_generate ()
{
    string code_string = "[M6 Codes]" + "\n";
    code_string += "Appartment: " + fourDigitCodeGenerate(10);

    return code_string;
}

string m66_generate()
{
    string[] lockers = new string[10];
    string code_string = "[M66 Codes]" + "\n";
    code_string += "Appartment: " + fourDigitCodeGenerate(10) + "\n";

    for (int i = 21; i <= 25; i++)
    {
        code_string += $"Locker {i} - {fourDigitCodeGenerate(9, 2)}".PadRight(20) + $"Locker {i + 10} - {fourDigitCodeGenerate(9, 3)}\n";
    }

    return code_string;
}

string m2a_room_names(int code)
{
    string room_name = "";

    switch (code)
    {
        case 1:
            room_name = "Room 1".PadRight(10) + " - " + fourDigitCodeGenerate(10, 1);
            break;
        case 2:
            room_name = "Room 2".PadRight(10) + " - " + fourDigitCodeGenerate(10, 2);
            break;
        case 3:
            room_name = "Room 3".PadRight(10) + " - " + fourDigitCodeGenerate(10, 3);
            break;
        case 4:
            room_name = "Room 4".PadRight(10) + " - " + fourDigitCodeGenerate(10, 4);
            break;
        case 5:
            room_name = "Room 5".PadRight(10) + " - " + fourDigitCodeGenerate(10, 5);
            break;
        case 6:
            room_name = "Vladaya".PadRight(10) + " - " + fourDigitCodeGenerate(10, 6);
            break;
        case 7:
            room_name = "Loft".PadRight(10) + " - " + fourDigitCodeGenerate(10, 7); ;
            break;
        case 8:
            room_name = "Loft 2".PadRight(10) + " - " + fourDigitCodeGenerate(10, 8);
            break;
        case 9:
            room_name = "Reception".PadRight(10) + " - " + fourDigitCodeGenerate(10, 9);
            break;
        case 10:
            room_name = "Box 1".PadRight(10) + " - " + fourDigitCodeGenerate(10, 0);
            break;
        case 11:
            room_name = "Box 2".PadRight(10) + " - " + fourDigitCodeGenerate(10, 0);
            break;
        case 12:
            room_name = "Box 3".PadRight(10) + " - " + fourDigitCodeGenerate(10, 0);
            break;
        default:
            room_name = "Some dark voodoo happening here mate.";
            break;
    }

    return room_name;
}

string m2a_generate()
{
    string code_string = "[M2A Codes]" + "\n";
    code_string += "Street: " + fourDigitCodeGenerate(10,9) + "\n";

    for (int i = 1; i <= 12; i++) {
        string special_char = i % 2 == 0 ? "\n" : "";
        code_string += m2a_room_names(i).PadRight(20) + special_char; 
    }

    return code_string;
}

int generateFourDigitsNumber_lastZero (int startingDigits)
{
    int number = Int32.Parse(fourDigitCodeGenerate(10, startingDigits));

    char[] number_array = number.ToString().ToCharArray();
    number_array[^1] = '1';
    number = Int32.Parse(new string(number_array));

    return number;
}
string bm_generate()
{
    string code_string = "[BM Codes]" + "\n";
    int box_code_start = generateFourDigitsNumber_lastZero(3);

    for (int i = 1; i <= 3; i++)
    {
        string special_char = i % 2 == 0 ? "\n" : "";
        code_string += $"Box {i} - {box_code_start}".PadRight(20) + special_char;
        box_code_start += 3;
    }

    return code_string;
}

string b31_generate()
{
    string code_string = "[B31 Codes]" + "\n";
    code_string += "Street: " + fourDigitCodeGenerate(10, 3) + "\n";
    int box_code_start = generateFourDigitsNumber_lastZero(1);

    for (int i = 1; i <= 4; i++)
    {
        string special_char = i % 2 == 0 ? "\n" : "";
        code_string += $"Box {i} - {box_code_start}".PadRight(20) + special_char;
        box_code_start += 3;
    }

    return code_string;
}

string b25_generate()
{
    string code_string = "[B25 Codes]" + "\n";
    code_string += "Street: " + fourDigitCodeGenerate(10, 2) + "\n";
    int box_code_first_floor_start = generateFourDigitsNumber_lastZero(1);
    int box_code_third_floor_start = generateFourDigitsNumber_lastZero(3);

    for (int i = 1; i <= 3; i++)
    {
        string special_char = i % 2 == 0 ? "\n" : "";
        code_string += $"Box {i} - {box_code_first_floor_start}".PadRight(20) + $"Box {i+3} - {box_code_third_floor_start}".PadRight(20) + "\n";
        box_code_first_floor_start += 3;
        box_code_third_floor_start += 3;
    }

    return code_string;
}

string ir_generate()
{
    string code_string = "[IR Codes]" + "\n";
    code_string += "Street: " + fourDigitCodeGenerate(10, 4) + "\n";
    code_string += "House: " + fourDigitCodeGenerate(10, 4) + "\n";
    int box_code_start = generateFourDigitsNumber_lastZero(2);

    for (int i = 1; i <= 4; i++)
    {
        string special_char = i % 2 == 0 ? "\n" : "";
        code_string += $"Box {i} - {box_code_start}".PadRight(20) + special_char;
        box_code_start += 3;
    }

    return code_string;
}

string b10_generate()
{
    string code_string = "[IR Codes]" + "\n";
    code_string += "Street: " + fourDigitCodeGenerate(10, 7) + "\n";
    code_string += "Appart: " + fourDigitCodeGenerate(10, 7) + "\n";
    int box_code_start = generateFourDigitsNumber_lastZero(3);

    for (int i = 1; i <= 4; i++)
    {
        string special_char = i % 2 == 0 ? "\n" : "";
        code_string += $"Box {i} - {box_code_start}".PadRight(20) + special_char;
        box_code_start += 3;
    }

    return code_string;
}


Console.WriteLine(m6_generate());
Console.WriteLine(m66_generate());
Console.WriteLine(m2a_generate());
Console.WriteLine(bm_generate());
Console.WriteLine(b31_generate());
Console.WriteLine(b25_generate());
Console.WriteLine(ir_generate());
Console.WriteLine(b10_generate());
