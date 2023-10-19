using System.ComponentModel.Design;
using System.Data;
using System.Runtime.InteropServices;

int[] turns = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

string[,] field = { { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" }, { "[ ]", "[ ]", "[ ]" } };
Print(field);
bool trigger = true;
int turn = 0;
int rotateNum = 0;
int firstTurn = 0;

while (trigger)
{
    Turn(field);
    Check(field);
    turn++;

    switch (firstTurn)
    {
        case 4: field = Rotate(field); field = Rotate(field); field = Rotate(field); rotateNum = 3; break;
        case 7: field = Rotate(field); field = Rotate(field); field = Rotate(field); rotateNum = 3; break;
        case 8: field = Rotate(field); field = Rotate(field); rotateNum = 2; break;
        case 9: field = Rotate(field); field = Rotate(field); rotateNum = 2; break;
        case 6: field = Rotate(field); rotateNum = 1; break;
        case 3: field = Rotate(field); rotateNum = 1; break;

    }

    if (turns[1] == 0)
    {
        switch (turns[0])
        {
            case 3: turns[0] = 1; break;
            case 7: turns[0] = 1; break;
            case 9: turns[0] = 1; break;
            case 4: turns[0] = 2; break;
            case 6: turns[0] = 2; break;
            case 8: turns[0] = 2; break;

        }
    }

    if (trigger && turn < 9)
    {
        field = MachineTurn(field, turn);
        Check(field);
        turn++;
    }
    else { Console.WriteLine("Ничья"); break; }

    if (!trigger)
    {
        Console.WriteLine("Компьютер победил");
    }
}

void Turn(string[,] array)
{
turn:
    int row = 0;
    int col = 0;
    int cell = Convert.ToInt32(Console.ReadLine());
    switch (cell)
    {
        case 1: row = 0; col = 0; break;
        case 2: row = 0; col = 1; break;
        case 3: row = 0; col = 2; break;
        case 4: row = 1; col = 0; break;
        case 5: row = 1; col = 1; break;
        case 6: row = 1; col = 2; break;
        case 7: row = 2; col = 0; break;
        case 8: row = 2; col = 1; break;
        case 9: row = 2; col = 2; break;
    }


    if (turns[0] == 0)
    {
        firstTurn = cell;
    }
    if (firstTurn != 1 && firstTurn != 2 && firstTurn != 5)
    {
        switch (firstTurn)
        {
            case 4:
                switch (cell)
                {
                    case 7: cell = 1; break;
                    case 4: cell = 2; break;
                    case 1: cell = 3; break;
                    case 8: cell = 4; break;
                    case 2: cell = 6; break;
                    case 9: cell = 7; break;
                    case 6: cell = 8; break;
                    case 3: cell = 9; break;
                }
                break;
            case 7:
                switch (cell)
                {
                    case 7: cell = 1; break;
                    case 4: cell = 2; break;
                    case 1: cell = 3; break;
                    case 8: cell = 4; break;
                    case 2: cell = 6; break;
                    case 9: cell = 7; break;
                    case 6: cell = 8; break;
                    case 3: cell = 9; break;
                }
                break;
            case 8:
                switch (cell)
                {
                    case 9: cell = 1; break;
                    case 8: cell = 2; break;
                    case 7: cell = 3; break;
                    case 6: cell = 4; break;
                    case 4: cell = 6; break;
                    case 3: cell = 7; break;
                    case 2: cell = 8; break;
                    case 1: cell = 9; break;
                }
                break;
            case 9:
                switch (cell)
                {
                    case 9: cell = 1; break;
                    case 8: cell = 2; break;
                    case 7: cell = 3; break;
                    case 6: cell = 4; break;
                    case 4: cell = 6; break;
                    case 3: cell = 7; break;
                    case 2: cell = 8; break;
                    case 1: cell = 9; break;
                }
                break;
            case 3:
                switch (cell)
                {
                    case 3: cell = 1; break;
                    case 6: cell = 2; break;
                    case 9: cell = 3; break;
                    case 2: cell = 4; break;
                    case 8: cell = 6; break;
                    case 1: cell = 7; break;
                    case 4: cell = 8; break;
                    case 7: cell = 9; break;
                }
                break;
            case 6:
                switch (cell)
                {
                    case 3: cell = 1; break;
                    case 6: cell = 2; break;
                    case 9: cell = 3; break;
                    case 2: cell = 4; break;
                    case 8: cell = 6; break;
                    case 1: cell = 7; break;
                    case 4: cell = 8; break;
                    case 7: cell = 9; break;
                }
                break;
        }
    }
    if (turns.Contains(cell))
    {
        Console.WriteLine("Вы не можете так сходить");
        goto turn;
    }
    array[row, col] = "[X]";
    turns[turn] = cell;

    Print(array);
}

void Check(string[,] array)
{
    if (array[0, 0] == array[0, 1] && array[0, 1] == array[0, 2] && array[0, 0] != "[ ]") { trigger = false; }
    if (array[1, 0] == array[1, 1] && array[1, 1] == array[1, 2] && array[1, 0] != "[ ]") { trigger = false; }
    if (array[2, 0] == array[2, 1] && array[2, 1] == array[2, 2] && array[2, 0] != "[ ]") { trigger = false; }
    if (array[0, 0] == array[1, 0] && array[1, 0] == array[2, 0] && array[0, 0] != "[ ]") { trigger = false; }
    if (array[0, 1] == array[1, 1] && array[1, 1] == array[2, 1] && array[0, 1] != "[ ]") { trigger = false; }
    if (array[0, 2] == array[1, 2] && array[1, 2] == array[2, 2] && array[0, 2] != "[ ]") { trigger = false; }
    if (array[0, 0] == array[1, 1] && array[1, 1] == array[2, 2] && array[0, 0] != "[ ]") { trigger = false; }
    if (array[0, 2] == array[1, 1] && array[1, 1] == array[2, 0] && array[0, 2] != "[ ]") { trigger = false; }
}

string[,] MachineTurn(string[,] array, int turn)
{
    // Первый ход в угол
    if (turns[0] == 1 && turns[1] == 0)
    {
        array[1, 1] = "[O]";
        turns[turn] = 5;
        goto print;
    }


    // Первый ход в центр
    if (turns[0] == 5 && turns[1] == 0)
    {
        array[0, 0] = "[O]";
        turns[turn] = 1;
        goto print;
    }

    // Первый ход в ребро
    if (turns[0] == 2 && turns[1] == 0)
    {
        array[0, 2] = "[O]";
        turns[turn] = 3;
        goto print;
    }

    // Ситуация 513, 517 (4 ход) генерирует 5137, 5173
    if ((turns[0] == 5 && turns[1] == 1 && (turns[2] == 3 || turns[2] == 7)) && turns[3] == 0)
    {
        if (turns[2] == 3)
        {
            array[2, 0] = "[O]";
            turns[3] = 7;
            goto print;
        }
        if (turns[2] == 7)
        {
            array[0, 2] = "[O]";
            turns[3] = 3;
            goto print;
        }
    }

    // Ситуация 512, 514, 516, 518
    if (turns[0] == 5 && turns[1] == 1 && (turns[2] == 2 || turns[2] == 4 || turns[2] == 6 || turns[2] == 8) && turns[3] == 0)
    {
        int index2 = turns[2];
        switch (index2)
        {
            case 2:
                array[2, 1] = "[O]";
                turns[3] = 8;
                goto print;
            case 4:
                array[1, 2] = "[O]";
                turns[3] = 6;
                goto print;
            case 6:
                array[1, 0] = "[O]";
                turns[3] = 4;
                goto print;
            case 8:
                array[0, 1] = "[O]";
                turns[3] = 2;
                goto print;
        }
    }

    // Ситуация 51374 (6 ход) генерирует 5137462, 5137468, 5137469
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 3 && turns[3] == 7 && turns[4] == 4 && turns[5] == 0)
    {
        array[1, 2] = "[O]";
        turns[5] = 6;
        goto print;
    }

    // Ситуация 51372 (6 ход) победа
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 3 && turns[3] == 7 && turns[4] == 2 && turns[5] == 0)
    {
        array[1, 0] = "[O]";
        turns[5] = 4;
        goto print;
    }

    // Ситуация 51376 (6 ход) победа
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 3 && turns[3] == 7 && turns[4] == 6 && turns[5] == 0)
    {
        array[1, 0] = "[O]";
        turns[5] = 4;
        goto print;
    }

    // Ситуация 51378 (6 ход) победа
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 3 && turns[3] == 7 && turns[4] == 8 && turns[5] == 0)
    {
        array[1, 0] = "[O]";
        turns[5] = 4;
        goto print;
    }

    // Ситуация 51379 (6 ход) победа
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 3 && turns[3] == 7 && turns[4] == 9 && turns[5] == 0)
    {
        array[1, 0] = "[O]";
        turns[5] = 4;
        goto print;
    }

    // Ситуация 5137462(8 ход), ничья
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 3 && turns[3] == 7 && turns[4] == 4 && turns[5] == 6 && turns[6] == 2 && turns[7] == 0)
    {
        array[2, 1] = "[O]";
        turns[7] = 8;
        goto print;
    }

    // Ситуация 5137468(8 ход), ничья
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 3 && turns[3] == 7 && turns[4] == 4 && turns[5] == 6 && turns[6] == 8 && turns[7] == 0)
    {
        array[0, 1] = "[O]";
        turns[7] = 2;
        goto print;
    }

    // Ситуация 5137469(8 ход), ничья
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 3 && turns[3] == 7 && turns[4] == 4 && turns[5] == 6 && turns[6] == 9 && turns[7] == 0)
    {
        array[0, 1] = "[O]";
        turns[7] = 2;
        goto print;
    }

    // Ситуация 51736 (6 ход) победа
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 7 && turns[3] == 3 && turns[4] == 6 && turns[5] == 0)
    {
        array[0, 1] = "[O]";
        turns[5] = 2;
        goto print;
    }

    // Ситуация 51738 (6 ход) победа
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 7 && turns[3] == 3 && turns[4] == 8 && turns[5] == 0)
    {
        array[0, 1] = "[O]";
        turns[5] = 2;
        goto print;
    }

    // Ситуация 51739 (6 ход) победа
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 7 && turns[3] == 3 && turns[4] == 9 && turns[5] == 0)
    {
        array[0, 1] = "[O]";
        turns[5] = 2;
        goto print;
    }

    // Ситуация 51734 (6 ход) победа
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 7 && turns[3] == 3 && turns[4] == 4 && turns[5] == 0)
    {
        array[0, 1] = "[O]";
        turns[5] = 2;
        goto print;
    }

    // Ситуация 51732 (6 ход), генерирует 5173284, 5173286, 5173289
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 7 && turns[3] == 3 && turns[4] == 2 && turns[5] == 0)
    {
        array[2, 1] = "[O]";
        turns[5] = 8;
        goto print;
    }

    // Ситуация 5173284
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 7 && turns[3] == 3 && turns[4] == 2 && turns[5] == 8 && turns[6] == 4 && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
        goto print;
    }

    // Ситуация 5173286
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 7 && turns[3] == 3 && turns[4] == 2 && turns[5] == 8 && turns[6] == 6 && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 5173289
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 7 && turns[3] == 3 && turns[4] == 2 && turns[5] == 8 && turns[6] == 9 && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 51283
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 3 && turns[5] == 0)
    {
        array[2, 0] = "[O]";
        turns[5] = 7;
        goto print;
    }

    // Ситуация 5128376, 5128379  
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 3 && turns[5] == 7 && (turns[6] == 6 || turns[6] == 9) && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 5128374
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 3 && turns[5] == 7 && turns[6] == 4 && turns[7] == 0)
    {
        array[2, 2] = "[O]";
        turns[5] = 9;
        goto print;
    }

    // Ситуация 51284
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 4 && turns[5] == 0)
    {
        array[1, 2] = "[O]";
        turns[5] = 6;
        goto print;
    }

    // Ситуация 5128463
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 4 && turns[5] == 6 && turns[6] == 3 && turns[7] == 0)
    {
        array[2, 0] = "[O]";
        turns[7] = 7;
    }

    // Ситуация 5128467
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 4 && turns[5] == 6 && turns[6] == 7 && turns[7] == 0)
    {
        array[0, 2] = "[O]";
        turns[7] = 3;
        goto print;
    }

    // Ситуация 5128469
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 4 && turns[5] == 6 && turns[6] == 9 && turns[7] == 0)
    {
        array[0, 2] = "[O]";
        turns[7] = 3;
        goto print;
    }

    // Ситуация 5128647
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 6 && turns[5] == 4 && turns[6] == 7 && turns[7] == 0)
    {
        array[0, 2] = "[O]";
        turns[7] = 3;
        goto print;
    }

    // Ситуация 5128643
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 6 && turns[5] == 4 && turns[6] == 3 && turns[7] == 0)
    {
        array[2, 0] = "[O]";
        turns[7] = 7;
        goto print;
    }

    // Ситуация 5128649
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 6 && turns[5] == 4 && turns[6] == 9 && turns[7] == 0)
    {
        array[2, 0] = "[O]";
        turns[7] = 7;
        goto print;
    }

    // Ситуация 51287
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 7 && turns[5] == 0)
    {
        array[0, 2] = "[O]";
        turns[5] = 3;
        goto print;
    }

    // Ситуация 5128734
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 7 && turns[5] == 3 && turns[6] == 4 && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
        goto print;
    }

    // Ситуация 5128736
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 7 && turns[5] == 3 && turns[6] == 6 && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 5128739
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 7 && turns[5] == 3 && turns[6] == 9 && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 51289
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 9 && turns[5] == 0)
    {
        array[0, 2] = "[O]";
        turns[5] = 3;
        goto print;
    }

    // Ситуация 5128934
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 9 && turns[5] == 3 && turns[6] == 4 && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
    }

    // Ситуация 5128936
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 9 && turns[5] == 3 && turns[6] == 6 && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 5128937
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 2 && turns[3] == 8 && turns[4] == 9 && turns[5] == 3 && turns[6] == 7 && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 51462
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 2 && turns[5] == 0)
    {
        array[2, 1] = "[O]";
        turns[5] = 8;
        goto print;
    }

    // Ситуация 5146283
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 2 && turns[5] == 8 && turns[6] == 3 && turns[7] == 0)
    {
        array[2, 0] = "[O]";
        turns[7] = 7;
        goto print;
    }

    // Ситуация 5146287
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 2 && turns[5] == 8 && turns[6] == 7 && turns[7] == 0)
    {
        array[0, 2] = "[O]";
        turns[7] = 3;
        goto print;
    }

    // Ситуация 5146289
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 2 && turns[5] == 8 && turns[6] == 9 && turns[7] == 0)
    {
        array[0, 2] = "[O]";
        turns[7] = 3;
        goto print;
    }

    //Ситуация 51463
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 3 && turns[5] == 0)
    {
        array[2, 0] = "[O]";
        turns[5] = 7;
        goto print;
    }

    // Ситуация 5146372
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 3 && turns[5] == 7 && turns[6] == 2 && turns[7] == 0)
    {
        array[2, 1] = "[O]";
        turns[7] = 8;
        goto print;
    }
    //Ситуация 5146378
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 3 && turns[5] == 7 && turns[6] == 8 && turns[7] == 0)
    {
        array[0, 1] = "[O]";
        turns[7] = 2;
        goto print;
    }
    //Ситуация 5146379
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 3 && turns[5] == 7 && turns[6] == 9 && turns[7] == 0)
    {
        array[0, 1] = "[O]";
        turns[7] = 2;
        goto print;
    }
    //Ситуация 51467
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 7 && turns[5] == 0)
    {
        array[0, 2] = "[O]";
        turns[5] = 3;
        goto print;
    }

    //Ситуация 5146732
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 7 && turns[5] == 3 && turns[6] == 2 && turns[7] == 0)
    {
        array[2, 2] = "[O]";
        turns[7] = 9;
        goto print;
    }

    // Ситуация 5146738
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 7 && turns[5] == 3 && turns[6] == 8 && turns[7] == 0)
    {
        array[2, 2] = "[O]";
        turns[7] = 9;
        goto print;
    }

    // Ситуация 5146739
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 7 && turns[5] == 3 && turns[6] == 9 && turns[7] == 0)
    {
        array[0, 1] = "[O]";
        turns[7] = 2;
        goto print;
    }

    // Ситуация 51468
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 8 && turns[5] == 0)
    {
        array[0, 1] = "[O]";
        turns[5] = 2;
        goto print;
    }

    // Ситуация 5146823
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 8 && turns[5] == 2 && turns[6] == 3 && turns[7] == 0)
    {
        array[2, 0] = "[O]";
        turns[7] = 7;
        goto print;
    }

    // Ситуация 5146827
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 8 && turns[5] == 2 && turns[6] == 7 && turns[7] == 0)
    {
        array[0, 2] = "[O]";
        turns[7] = 3;
        goto print;
    }

    // Ситуация 5146829
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 8 && turns[5] == 2 && turns[6] == 9 && turns[7] == 0)
    {
        array[0, 2] = "[O]";
        turns[7] = 3;
        goto print;
    }

    // Ситуация 51469
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 9 && turns[5] == 0)
    {
        array[0, 2] = "[O]";
        turns[5] = 3;
        goto print;
    }

    // Ситуация 5146932
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 9 && turns[5] == 3 && turns[6] == 2 && turns[7] == 0)
    {
        array[2, 1] = "[O]";
        turns[7] = 8;
        goto print;
    }

    // Ситуация 5146937
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 9 && turns[5] == 3 && turns[6] == 7 && turns[7] == 0)
    {
        array[0, 1] = "[O]";
        turns[7] = 2;
        goto print;
    }

    // Ситуация 5146938
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 4 && turns[3] == 6 && turns[4] == 9 && turns[5] == 3 && turns[6] == 8 && turns[7] == 0)
    {
        array[0, 1] = "[O]";
        turns[7] = 2;
        goto print;
    }

    // Ситуация 51642, 51643, 51648, 51649
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 6 && turns[3] == 4 && (turns[4] == 2 || turns[4] == 3 || turns[4] == 8 || turns[4] == 9) && turns[5] == 0)
    {
        array[2, 0] = "[O]";
        turns[5] = 7;
        goto print;
    }

    // Ситуация 51647
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 6 && turns[3] == 4 && turns[4] == 7 && turns[5] == 0)
    {
        array[0, 2] = "[O]";
        turns[5] = 3;
        goto print;
    }

    // Ситуация 5164738, 5164739
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 6 && turns[3] == 4 && turns[4] == 7 && turns[5] == 3 && (turns[6] == 8 || turns[6] == 9) && turns[7] == 0)
    {
        array[0, 1] = "[O]";
        turns[7] = 2;
        goto print;
    }

    // Ситуация 5164732
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 6 && turns[3] == 4 && turns[4] == 7 && turns[5] == 3 && turns[6] == 2 && turns[7] == 0)
    {
        array[2, 1] = "[O]";
        turns[7] = 8;
        goto print;
    }

    // Ситуация 519
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 9 & turns[3] == 0)
    {
        array[2, 0] = "[O]";
        turns[3] = 7;
        goto print;
    }

    // Ситуация 51972, 51973, 51976, 51978
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 9 && turns[3] == 7 && (turns[4] == 2 || turns[4] == 3 || turns[4] == 6 || turns[4] == 8) && turns[5] == 0)
    {
        array[1, 0] = "[O]";
        turns[5] = 4;
        goto print;
    }

    // Ситуация 51974
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 9 && turns[3] == 7 && turns[4] == 4 && turns[5] == 0)
    {
        array[1, 2] = "[O]";
        turns[5] = 6;
        goto print;
    }

    // Ситуация 5197462
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 9 && turns[3] == 7 && turns[4] == 4 && turns[5] == 6 && turns[6] == 2 && turns[7] == 0)
    {
        array[2, 1] = "[O]";
        turns[7] = 8;
        goto print;
    }

    // Ситуация 5197463
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 9 && turns[3] == 7 && turns[4] == 4 && turns[5] == 6 && turns[6] == 3 && turns[7] == 0)
    {
        array[0, 1] = "[O]";
        turns[7] = 2;
        goto print;
    }

    // Ситуация 5197468
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 9 && turns[3] == 7 && turns[4] == 4 && turns[5] == 6 && turns[6] == 8 && turns[7] == 0)
    {
        array[0, 1] = "[O]";
        turns[7] = 2;
        goto print;
    }

    // Ситуация 51824, 51826, 51827, 51829
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 8 && turns[3] == 2 && (turns[4] == 4 || turns[4] == 6 || turns[4] == 7 || turns[4] == 9) && turns[5] == 0)
    {
        array[0, 2] = "[O]";
        turns[5] = 3;
        goto print;
    }

    // Ситуация 51823
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 8 && turns[3] == 2 && turns[4] == 3 && turns[5] == 0)
    {
        array[2, 0] = "[O]";
        turns[5] = 7;
        goto print;
    }

    // Ситуация 5182376, 5182379
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 8 && turns[3] == 2 && turns[4] == 3 && turns[5] == 7 && (turns[6] == 6 || turns[6] == 9) && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[6] = 4;
        goto print;
    }

    // Ситуация 5182374
    if (turns[0] == 5 && turns[1] == 1 && turns[2] == 8 && turns[3] == 2 && turns[4] == 3 && turns[5] == 7 && turns[6] == 4 && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
        goto print;
    }

    // Ситуация 152
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 2 && turns[3] == 0)
    {
        array[0, 2] = "[O]";
        turns[3] = 3;
        goto print;
    }

    // Ситуация 15234, 15236, 15238, 15239
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 2 && turns[3] == 3 && (turns[4] == 4 || turns[4] == 6 || turns[4] == 8 || turns[4] == 9) && turns[5] == 0)
    {
        array[2, 0] = "[O]";
        turns[3] = 7;
        goto print;
    }

    // Ситуация 15237
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 2 && turns[3] == 3 && turns[4] == 7 && turns[5] == 0)
    {
        array[1, 0] = "[O]";
        turns[5] = 4;
        goto print;
    }

    // Ситуация 1523746
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 2 && turns[3] == 3 && turns[4] == 7 && turns[5] == 4 && turns[6] == 6 && turns[7] == 0)
    {
        array[2, 1] = "[O]";
        turns[7] = 8;
        goto print;
    }

    // Ситуация 1523749, 1523748
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 2 && turns[3] == 3 && turns[4] == 7 && turns[5] == 4 && (turns[6] == 9 || turns[6] == 8) && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
        goto print;
    }

    // Ситуация 153
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 3 && turns[3] == 0)
    {
        array[0, 1] = "[O]";
        turns[3] = 2;
        goto print;
    }

    // Ситуация 15324, 15326, 15327, 15329
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 3 && turns[3] == 2 && (turns[4] == 4 || turns[4] == 6 || turns[4] == 7 || turns[4] == 9) && turns[5] == 0)
    {
        array[2, 1] = "[O]";
        turns[5] = 8;
        goto print;
    }

    // Ситуация 15328
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 3 && turns[3] == 2 && turns[4] == 8 && turns[5] == 0)
    {
        array[2, 0] = "[O]";
        turns[5] = 7;
        goto print;
    }

    // Ситуация 1532874, 1532879
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 3 && turns[3] == 2 && turns[4] == 8 && turns[5] == 7 && (turns[6] == 4 || turns[6] == 9) && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
        goto print;
    }

    // Ситуация 1532876
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 3 && turns[3] == 2 && turns[4] == 8 && turns[5] == 7 && turns[6] == 6 && turns[7] == 0)
    {
        array[2, 2] = "[O]";
        turns[7] = 9;
        goto print;
    }

    // Ситуация 154
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 4 && turns[3] == 0)
    {
        array[2, 0] = "[O]";
        turns[3] = 7;
        goto print;
    }

    // Ситуация 15472, 15476, 15478, 15479
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 4 && turns[3] == 7 && (turns[4] == 2 || turns[4] == 6 || turns[4] == 8 || turns[4] == 9) && turns[5] == 0)
    {
        array[0, 2] = "[O]";
        turns[5] = 3;
        goto print;
    }

    // Ситуация 15473
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 4 && turns[3] == 7 && turns[4] == 3 && turns[5] == 0)
    {
        array[0, 1] = "[O]";
        turns[5] = 2;
        goto print;
    }

    // Ситуация 1547326, 1547329
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 4 && turns[3] == 7 && turns[4] == 3 && turns[5] == 2 && (turns[6] == 6 || turns[6] == 9) && turns[7] == 0)
    {
        array[2, 1] = "[O]";
        turns[7] = 8;
        goto print;
    }

    // Ситуация 1547328
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 4 && turns[3] == 7 && turns[4] == 3 && turns[5] == 2 && turns[6] == 8 && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
        goto print;
    }

    // Ситуация 156
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 6 && turns[3] == 0)
    {
        array[0, 1] = "[O]";
        turns[3] = 2;
        goto print;
    }

    // Ситуация 15623, 15624, 15627, 15629
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 6 && turns[3] == 2 && (turns[4] == 3 || turns[4] == 4 || turns[4] == 7 || turns[4] == 9) && turns[5] == 0)
    {
        array[2, 1] = "[O]";
        turns[5] = 8;
        goto print;
    }

    // Ситуация 15628
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 6 && turns[3] == 2 && turns[4] == 8 && turns[5] == 0)
    {
        array[2, 2] = "[O]";
        turns[5] = 9;
        goto print;
    }

    // Ситуация 1562893, 1562897
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 6 && turns[3] == 2 && turns[4] == 8 && turns[5] == 9 && (turns[6] == 3 || turns[6] == 7) && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 1562894
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 6 && turns[3] == 2 && turns[4] == 8 && turns[5] == 9 && turns[6] == 4 && turns[7] == 0)
    {
        array[2, 0] = "[O]";
        turns[7] = 7;
        goto print;
    }

    // Ситуация 157
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 7 && turns[3] == 0)
    {
        array[1, 0] = "[O]";
        turns[3] = 4;
        goto print;
    }

    // Ситуация 15742, 15743, 15748, 15749
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 7 && turns[3] == 4 && (turns[4] == 2 || turns[4] == 3 || turns[4] == 8 || turns[4] == 9) && turns[5] == 0)
    {
        array[1, 2] = "[O]";
        turns[5] = 6;
        goto print;
    }

    // Ситуация 15746
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 7 && turns[3] == 4 && turns[4] == 6 && turns[5] == 0)
    {
        array[0, 1] = "[O]";
        turns[5] = 2;
        goto print;
    }

    // Ситуация 1574623, 1574629
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 7 && turns[3] == 4 && turns[4] == 6 && turns[5] == 2 && (turns[6] == 3 || turns[6] == 9) && turns[7] == 0)
    {
        array[2, 1] = "[O]";
        turns[7] = 8;
        goto print;
    }

    // Ситуация 1574628
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 7 && turns[3] == 4 && turns[4] == 6 && turns[5] == 2 && turns[6] == 8 && turns[7] == 0)
    {
        array[2, 2] = "[O]";
        turns[7] = 9;
        goto print;
    }

    // Ситуация 158
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 8 && turns[3] == 0)
    {
        array[2, 0] = "[O]";
        turns[3] = 7;
        goto print;
    }

    // Ситуация 15872, 15874, 15876, 15879
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 8 && turns[3] == 7 && (turns[4] == 2 || turns[4] == 4 || turns[4] == 6 || turns[4] == 9) && turns[5] == 0)
    {
        array[0, 2] = "[O]";
        turns[5] = 3;
        goto print;
    }

    // Ситуация 15873
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 8 && turns[3] == 7 && turns[4] == 3 && turns[5] == 0)
    {
        array[0, 1] = "[O]";
        turns[5] = 2;
        goto print;
    }

    // Ситуация 1587324, 1587326
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 8 && turns[3] == 7 && turns[4] == 3 && turns[5] == 2 && (turns[6] == 4 || turns[6] == 6) && turns[7] == 0)
    {
        array[2, 2] = "[O]";
        turns[7] = 9;
        goto print;
    }

    // Ситуация 1587329
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 8 && turns[3] == 7 && turns[4] == 3 && turns[5] == 2 && turns[6] == 9 && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
        goto print;
    }

    // Ситуация 159
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 9 && turns[3] == 0)
    {
        array[1, 0] = "[O]";
        turns[3] = 4;
        goto print;
    }

    // Ситуация 15942, 15943, 15947, 15948
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 9 && turns[3] == 4 && (turns[4] == 2 || turns[4] == 3 || turns[4] == 7 || turns[4] == 8) && turns[5] == 0)
    {
        array[1, 2] = "[O]";
        turns[5] = 6;
        goto print;
    }

    // Ситуация 15946
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 9 && turns[3] == 4 && turns[4] == 6 && turns[5] == 0)
    {
        array[0, 2] = "[O]";
        turns[5] = 3;
        goto print;
    }

    // Ситуация 1594632, 1594638
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 9 && turns[3] == 4 && turns[4] == 6 && turns[5] == 3 && (turns[6] == 2 || turns[6] == 8) && turns[7] == 0)
    {
        array[2, 0] = "[O]";
        turns[7] = 7;
        goto print;
    }

    // Ситуация 1594637
    if (turns[0] == 1 && turns[1] == 5 && turns[2] == 9 && turns[3] == 4 && turns[4] == 6 && turns[5] == 3 && turns[6] == 7 && turns[7] == 0)
    {
        array[2, 1] = "[O]";
        turns[7] = 8;
        goto print;
    }

    // Ситуация 231
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 1 && turns[3] == 0)
    {
        array[1, 2] = "[O]";
        turns[3] = 6;
        goto print;
    }

    // Ситуация 23164, 23165, 23167, 23168
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 1 && turns[3] == 6 && (turns[4] == 4 || turns[4] == 5 || turns[4] == 7 || turns[4] == 8) && turns[5] == 0)
    {
        array[2, 2] = "[O]";
        turns[5] = 9;
        goto print;
    }

    // Ситуация 23169
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 1 && turns[3] == 6 && turns[4] == 9 && turns[5] == 0)
    {
        array[1, 1] = "[O]";
        turns[5] = 5;
        goto print;
    }

    // Ситуация 2316957, 2316958
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 1 && turns[3] == 6 && turns[4] == 9 && turns[5] == 5 && (turns[6] == 7 || turns[6] == 8) && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 2316954
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 1 && turns[3] == 6 && turns[4] == 9 && turns[5] == 5 && turns[6] == 4 && turns[7] == 0)
    {
        array[2, 0] = "[O]";
        turns[7] = 7;
        goto print;
    }

    // Ситуация 234
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 4 && turns[3] == 0)
    {
        array[2, 2] = "[O]";
        turns[3] = 9;
        goto print;
    }

    // Ситуация 23491, 23495, 23497, 23498
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 4 && turns[3] == 9 && (turns[4] == 1 || turns[4] == 5 || turns[4] == 7 || turns[4] == 8) && turns[5] == 0)
    {
        array[1, 2] = "[O]";
        turns[5] = 6;
        goto print;
    }

    // Ситуация 23496
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 4 && turns[3] == 9 && turns[4] == 6 && turns[5] == 0)
    {
        array[1, 1] = "[O]";
        turns[5] = 5;
        goto print;
    }

    // Ситуация 2349651, 2349658
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 4 && turns[3] == 9 && turns[4] == 6 && turns[5] == 5 && (turns[6] == 1 || turns[6] == 8) && turns[7] == 0)
    {
        array[2, 0] = "[O]";
        turns[7] = 7;
        goto print;
    }

    // Ситуация 2349657
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 4 && turns[3] == 9 && turns[4] == 6 && turns[5] == 5 && turns[6] == 7 && turns[7] == 0)
    {
        array[0, 0] = "[O]";
        turns[7] = 1;
        goto print;
    }

    // Ситуация 235
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 0)
    {
        array[2, 1] = "[O]";
        turns[3] = 8;
        goto print;
    }

    // Ситуация 23581
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 1 && turns[5] == 0)
    {
        array[2, 2] = "[O]";
        turns[5] = 9;
        goto print;
    }

    // Ситуация 23584
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 4 && turns[5] == 0)
    {
        array[1, 2] = "[O]";
        turns[5] = 6;
        goto print;
    }

    // Ситуация 23586
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 6 && turns[5] == 0)
    {
        array[1, 0] = "[O]";
        turns[5] = 4;
        goto print;
    }

    // Ситуация 23587
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 7 && turns[5] == 0)
    {
        array[2, 2] = "[O]";
        turns[5] = 9;
        goto print;
    }

    // Ситуация 23589
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 9 && turns[5] == 0)
    {
        array[0, 0] = "[O]";
        turns[5] = 1;
        goto print;
    }

    // Ситуация 2358194, 2358196
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 1 && turns[5] == 9 && (turns[6] == 4 || turns[6] == 6) && turns[7] == 0)
    {
        array[2, 0] = "[O]";
        turns[7] = 7;
        goto print;
    }

    // Ситуация 2358197
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 1 && turns[5] == 9 && turns[6] == 7 && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
        goto print;
    }

    // Ситуация 2358461, 2358467
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 4 && turns[5] == 6 && (turns[6] == 1 || turns[6] == 7) && turns[7] == 0)
    {
        array[2, 2] = "[O]";
        turns[7] = 9;
        goto print;
    }

    // Ситуация 2358469
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 4 && turns[5] == 6 && turns[6] == 9 && turns[7] == 0)
    {
        array[0, 0] = "[O]";
        turns[7] = 1;
        goto print;
    }

    // Ситуация 2358641, 2358647
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 6 && turns[5] == 4 && (turns[6] == 1 || turns[6] == 7) && turns[7] == 0)
    {
        array[2, 2] = "[O]";
        turns[7] = 9;
        goto print;
    }

    // Ситуация 2358649
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 6 && turns[5] == 4 && turns[6] == 9 && turns[7] == 0)
    {
        array[0, 0] = "[O]";
        turns[7] = 1;
        goto print;
    }

    // Ситуация 2358791, 2358794
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 7 && turns[5] == 9 && (turns[6] == 1 || turns[6] == 4) && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
        goto print;
    }

    // Ситуация 2358796
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 7 && turns[5] == 9 && turns[6] == 6 && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 2358914, 2358917
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 9 && turns[5] == 1 && (turns[6] == 4 || turns[6] == 7) && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
        goto print;
    }


    // Ситуация 2358916
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 5 && turns[3] == 8 && turns[4] == 9 && turns[5] == 1 && turns[6] == 6 && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 236
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 6 && turns[3] == 0)
    {
        array[1, 1] = "[O]";
        turns[3] = 5;
        goto print;
    }

    // Ситуация 23651, 23654, 23658, 23659
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 6 && turns[3] == 5 && (turns[4] == 1 || turns[4] == 4 || turns[4] == 8 || turns[4] == 9) && turns[5] == 0)
    {
        array[2, 0] = "[O]";
        turns[5] = 7;
        goto print;
    }

    // Ситуация 23657
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 6 && turns[3] == 5 && turns[4] == 7 && turns[5] == 0)
    {
        array[0, 0] = "[O]";
        turns[5] = 1;
        goto print;
    }

    // Ситуация 2365714, 2365718
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 6 && turns[3] == 5 && turns[4] == 7 && turns[5] == 1 && (turns[6] == 4 || turns[6] == 8) && turns[7] == 0)
    {
        array[2, 2] = "[O]";
        turns[7] = 9;
        goto print;
    }

    // Ситуация 2365719
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 6 && turns[3] == 5 && turns[4] == 7 && turns[5] == 1 && turns[6] == 9 && turns[7] == 0)
    {
        array[2, 1] = "[O]";
        turns[7] = 8;
        goto print;
    }

    // Ситуация 237
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 7 && turns[3] == 0)
    {
        array[2, 2] = "[O]";
        turns[3] = 9;
        goto print;
    }

    // Ситуация 23791, 23794, 23795, 23798
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 7 && turns[3] == 9 && (turns[4] == 1 || turns[4] == 4 || turns[4] == 5 || turns[4] == 8) && turns[5] == 0)
    {
        array[1, 2] = "[O]";
        turns[5] = 6;
        goto print;
    }

    // Ситуация 23796
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 7 && turns[3] == 9 && turns[4] == 6 && turns[5] == 0)
    {
        array[1, 1] = "[O]";
        turns[5] = 5;
        goto print;
    }

    // Ситуация 2379654, 2379658
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 7 && turns[3] == 9 && turns[4] == 6 && turns[5] == 5 && (turns[6] == 4 || turns[6] == 8) && turns[7] == 0)
    {
        array[0, 0] = "[O]";
        turns[7] = 1;
        goto print;
    }

    // Ситуация 2379651
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 7 && turns[3] == 9 && turns[4] == 6 && turns[5] == 5 && turns[6] == 1 && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

    // Ситуация 238
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 8 && turns[3] == 0)
    {
        array[1, 1] = "[O]";
        turns[3] = 5;
        goto print;
    }

    // Ситуация 23851, 23854, 23856, 23859
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 8 && turns[3] == 5 && (turns[4] == 1 || turns[4] == 4 || turns[4] == 6 || turns[4] == 9) && turns[5] == 0)
    {
        array[2, 0] = "[O]";
        turns[5] = 7;
        goto print;
    }

    // Ситуация 23857
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 8 && turns[3] == 5 && turns[4] == 7 && turns[5] == 0)
    {
        array[2, 2] = "[O]";
        turns[5] = 9;
        goto print;
    }

    // Ситуация 2385791, 2385794
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 8 && turns[3] == 5 && turns[4] == 7 && turns[5] == 9 && (turns[6] == 1 || turns[6] == 4) && turns[7] == 0)
    {
        array[1, 2] = "[O]";
        turns[7] = 6;
        goto print;
    }

    // Ситуация 2385796
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 8 && turns[3] == 5 && turns[4] == 7 && turns[5] == 9 && turns[6] == 6 && turns[7] == 0)
    {
        array[0, 0] = "[O]";
        turns[7] = 1;
        goto print;
    }

    // Ситуация 239
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 9 && turns[3] == 0)
    {
        array[1, 1] = "[O]";
        turns[3] = 5;
        goto print;
    }

    // Ситуация 23951, 23954, 23956, 23958
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 9 && turns[3] == 5 && (turns[4] == 1 || turns[4] == 4 || turns[4] == 6 || turns[4] == 8) && turns[5] == 0)
    {
        array[2, 0] = "[O]";
        turns[5] = 7;
        goto print;
    }

    // Ситуация 23957
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 9 && turns[3] == 5 && turns[4] == 7 && turns[5] == 0)
    {
        array[2, 1] = "[O]";
        turns[5] = 8;
        goto print;
    }

    // Ситуация 2395784, 2395786
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 9 && turns[3] == 5 && turns[4] == 7 && turns[5] == 8 && (turns[6] == 4 || turns[6] == 6) && turns[7] == 0)
    {
        array[0, 0] = "[O]";
        turns[7] = 1;
        goto print;
    }

    // Ситуация 2395781
    if (turns[0] == 2 && turns[1] == 3 && turns[2] == 9 && turns[3] == 5 && turns[4] == 7 && turns[5] == 8 && turns[6] == 1 && turns[7] == 0)
    {
        array[1, 0] = "[O]";
        turns[7] = 4;
        goto print;
    }

print:
    switch (rotateNum)
    {
        case 0: break;
        case 1: array = Rotate(array); array = Rotate(array); array = Rotate(array); rotateNum = 0; break;
        case 2: array = Rotate(array); array = Rotate(array); break;
        case 3: array = Rotate(array); rotateNum = 0; break;
    }
    Print(array);
    return array;
}

void Print(string[,] array)
{
    Console.Clear();
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}

static string[,] Rotate(string[,] oldMatrix)
{
    string[,] newMatrix = new string[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
    int newColumn, newRow = 0;

    newMatrix = new string[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
    newColumn = 0;
    newRow = 0;
    for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
    {
        newColumn = 0;
        for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
        {
            newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
            newColumn++;
        }
        newRow++;
    }

    return newMatrix;
}
