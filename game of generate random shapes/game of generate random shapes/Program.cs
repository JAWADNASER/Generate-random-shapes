using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace GeometryQuizGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("===================================================================================");
            Console.WriteLine("                           GEOMETRY SHAPE QUIZ GAME                                ");
            Console.WriteLine("===================================================================================");

            //====================================================================================================
            //                                          SECTION 1:
            //====================================================================================================

            //=============================
            // PRINT DEVICE INFORMATION
            //=============================
            Console.WriteLine("\n---------------------------------------------------------------------------------");
            Console.WriteLine("Windows version: " + Environment.OSVersion);
            Console.WriteLine("64 Bit operating system?: " + (Environment.Is64BitOperatingSystem ? "Yes" : "No"));
            Console.WriteLine("PC Name: " + Environment.MachineName);
            Console.WriteLine("Number of CPUs: " + Environment.ProcessorCount);
            Console.WriteLine("Windows folder: " + Environment.SystemDirectory);
            Console.WriteLine("Logical Drives Available : {0}", String.Join(", ", Environment.GetLogicalDrives()).TrimEnd(',', ' ').Replace("\\", String.Empty));
            Console.WriteLine("---------------------------------------------------------------------------------");


            //==================================================
            // 1. PRINT AVAILABLE SHAPES AND THEIR SIDES NUMBER
            //==================================================
            Console.WriteLine("//==================================================\n" +
                               "// 1. PRINT AVAILABLE SHAPES AND THEIR SIDES NUMBER\n" +
                                "//==================================================");
            Console.WriteLine("The available shapes are:");
            Console.WriteLine("Circle        : 1\n" +
                              "Cylinder      : 2\n" +
                              "Triangle      : 3\n" +
                              "Quadrilateral : 4\n" +
                              "Pentagon      : 5");
            Console.WriteLine("---------------------------------------------------------------------------------");

            //=======================================================
            // 2. READ HOW MANY QUESTIONS DO THE USER WANT TO ANSWER
            //=======================================================

            Console.WriteLine("//==================================================\n" +
                               "// 2. READ HOW MANY QUESTIONS DO THE USER WANT TO ANSWER\n" +
                                "//==================================================\n");
            Console.WriteLine("Please enter the maximum number of questions: ");
            int number_of_questions = int.Parse(Console.ReadLine());
            while (!(number_of_questions > 0))
            {
                Console.WriteLine("The number should be an integer > 0, Please enter it again: ");
                number_of_questions = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("---------------------------------------------------------------------------------");

            //==========================
            // 3. READ USER INFORMATION
            //==========================
            Console.WriteLine("//==================================================\n" +
                   "// 3. READ USER INFORMATION\n" +
                    "//==================================================\n");
            string user_info = "";
            bool has_consecutive_duplicates = false;
            bool has_invalid_chars = false;
            do
            {
                Console.WriteLine("Enter your full name, SVU ID, hobbies, and favorite color:");
                Console.WriteLine("(Accepted characters: A-Z, a-z, 0-9, /, \\, ?, and space).");
                user_info = Console.ReadLine();

                has_consecutive_duplicates = false;
                has_invalid_chars = false;

                // Check length
                if (user_info.Length < 6)
                {
                    Console.WriteLine("The text must be at least 6 characters long.");
                    continue;
                }

                // Check for invalid characters
                for (int i = 0; i < user_info.Length; i++)
                {
                    char c = user_info[i]; // get current character
                    if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == '/' || c == '\\' || c == '?' || c == ' '))// if invalid
                    {
                        has_invalid_chars = true;
                        break;
                    }
                }

                if (has_invalid_chars)
                {
                    Console.WriteLine("The text contains invalid characters. Try again.");
                    continue;
                }

                // Check for consecutive duplicate characters
                for (int i = 1; i < user_info.Length; i++)
                {
                    if (user_info[i] == user_info[i - 1] && user_info[i] == user_info[i + 1])
                    {
                        has_consecutive_duplicates = true;
                        break;
                    }
                }

                if (has_consecutive_duplicates)
                {
                    Console.WriteLine("You cannot use the same character more than 2 times in a row. Try again.");
                }

            } while (user_info.Length < 6 || has_invalid_chars || has_consecutive_duplicates);

            // PRINT DISTINCT CHARS:
            string distinct_string = "";
            for (int i = 0; i < user_info.Length; i++)
            {
                char currentChar = user_info[i];
                bool found = false;

                for (int j = 1; j < distinct_string.Length; j++)
                {
                    if (distinct_string[j] == currentChar)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    distinct_string += currentChar;
                }
            }
            Console.WriteLine("\nDistinct chars are:\n " + distinct_string);
            Console.WriteLine("---------------------------------------------------------------------------------");

            //=====================================
            // 4. READ USER SUGGESTION FOR A SHAPE
            //=====================================
            Console.WriteLine("//==================================================\n" +
                               "// 4. READ USER SUGGESTION FOR SHAPE\n" +
                               "//==================================================\n");

            // READ SHAPE NAME:
            string user_shape_name = "";
            Console.WriteLine("Enter valid shape name (Circle, Cylinder, Triangle, Quadrilateral, Pentagon): ");
            Boolean flag = false;
            while (!flag)
            {
                user_shape_name = Console.ReadLine();
                string user_shape_name1 = user_shape_name.ToUpper();
                if (!((user_shape_name1 == "Circle".ToUpper()) || (user_shape_name1 == "Cylinder".ToUpper()) || (user_shape_name1 == "Triangle".ToUpper()) || (user_shape_name1 == "Quadrilateral".ToUpper()) || (user_shape_name1 == "Pentagon".ToUpper())))
                {
                    Console.WriteLine("The text contains invalid values. Try again. Enter valid shape name (Circle, Cylinder, Triangle, Quadrilateral, Pentagon): ");
                }
                else
                {
                    flag = true;
                }
            }

            // READ NUMBER OF SIDES
            Console.WriteLine("\nEnter number of sides: ");
            int number_of_sides;
            number_of_sides = int.Parse(Console.ReadLine());
            if (!(number_of_sides > 0))
            {
                Console.WriteLine("The text contains invalid values. Try again.\nEnter integer number of sides > 0 : ");
            }

            // READ SIDES LENGTH
            int[] sides_length = new int[number_of_sides];
            for (int i = 0; i < number_of_sides; i++)
            {
                int s = i + 1;
                Console.WriteLine("\nEnter the length of the side " + s + " : ");
                sides_length[i] = int.Parse(Console.ReadLine());
                if (!(sides_length[i] > 0))
                {
                    Console.WriteLine("The text contains invalid values. Try again.\nEnter the length of the side > " + s + " : ");
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------------");

            //=====================================
            // 5. GENERATE SHAPES RANDOMLY
            // 7. (A) STORAGE ACTUAL NAME SHAPES RANDOMLY, TESTING NAMES SHAPES RANDOMLY, SIDE LENGTHS RANDOMLY, AND SUM SIDE LENGTHS IN ARRAYS.
            //=====================================

            Console.WriteLine("//==================================================\n" +
                                            "//      START THE QUIZ:\n" +
                               "//==================================================");

            //GENERATE NAME SHAPES AND SIDE LENGTHS RANDOMLY, AND STORAGE'S IN ARRAYS
            Random random = new Random();
            int row = number_of_questions;
            int cols = 3;
            string[] shap = { "Circle", "Cylinder", "Triangle", "Quadrilateral", "Pentagon" };
            string[] generate_random_name_shap = new string[number_of_questions];
            int[] number_sides = new int[number_of_questions];
            int[] length_side = new int[0];
            string[] generate_random_name_shap_test = new string[number_of_questions];
            int[] lengthes_sides_sum = new int[number_of_questions];
            int[] actul_name_shape = new int[number_of_questions];
            int[] name_shap_verifiable = new int[number_of_questions];
            int[] answer_actual_name_shape = new int[number_of_questions];
            int[] answer_lengthes_sides_sum = new int[number_of_questions];
            int[] answer_verifiable = new int[number_of_questions];
            int[,] correct_answer = new int[row, cols];
            int[,] user_answer = new int[row, cols];
            string answer_input_sum;
            int[] user_answer_rating = new int[number_of_questions];
            int count = 1;
            int index = 0;
            int q = 0;

            for (int i = 0; i < number_of_questions; i++)
            {
                q = i + 1;
                Console.WriteLine("\n====Question" + q + ":====\n");
                generate_random_name_shap[i] = shap[random.Next(0, 5)];// RANDOMLY GENERATE NAME SHAPE, AND STORAGE'S IN ARRAY

                switch (generate_random_name_shap[i])
                {
                    case "Circle":
                        index = 1;
                        break;

                    case "Cylinder":
                        index = 2;
                        break;

                    case "Triangle":
                        index = 3;
                        break;

                    case "Quadrilateral":
                        index = 4;
                        break;

                    case "Pentagon":
                        index = 5;
                        break;
                }

                generate_random_name_shap_test[i] = shap[random.Next(0, 5)];// RANDOMLY GENERATE NAME SHAPE AGAIN FOR USER TESTING AND STORAGE'S IN ARRAY
                Console.Write("Shape Name : " + generate_random_name_shap_test[i]);

                if (index > 0)
                {
                    length_side = new int[index];
                    number_sides[i] = index;        //STORAGE NUMBER SIDES FOR ALL QUESTIONS IN ARRAY.

                    Console.Write("\nSides lengthes : ");
                    for (int j = 0; j < index; j++) // GENERATE SIDE LENGTHS RANDOMLY BASED ON SHAPE BETWEEN 1 AND 20, AND STOAGE'S IN ARRAY
                    {
                        length_side[j] = random.Next(1, 21);
                        lengthes_sides_sum[i] += length_side[j]; // SUM SIDE LENGTHS AND STORGE'S IN ARRAY
                        Console.Write(length_side[j] + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Error: Unknown shape type");
                    continue;
                }

                //=====================================
                // 6. USER TESTING
                // 7. (A) STORE USER ANSWERS AND CORRECT ANSWERS IN ARRAYS 
                //=====================================

                // ENTER SUM LENGTHS SIDES BY USER OR IGNORE THE ANSWER, AND STORE USER ANSWERS AND CORRECT ANSWERS IN ARRAYS.

                Console.WriteLine("\nEnter the sum of the lengths of the previous shape, Or Enter (Ignore) for ignore the question : \n");
                answer_input_sum = Console.ReadLine().ToLower();
                correct_answer[i, 0] = lengthes_sides_sum[i];
                if (answer_input_sum == "ignore")
                {
                    answer_lengthes_sides_sum[i] = 0;
                    user_answer[i, 0] = 0;
                }
                else
                {
                    answer_lengthes_sides_sum[i] = int.Parse(answer_input_sum);
                    user_answer[i, 0] = answer_lengthes_sides_sum[i];
                }

                // TESTING IF THE SHAP IS VERIFIABLE OR NOT, ENTER THE USER'S ANSWER, AND STORE USER ANSWERS AND CORRECT ANSWERS IN ARRAYS.

                Console.WriteLine("\nEnter 1 ===== If the shape is verifiable (YES).\nEnter 2 ===== If the shape isn't verifiable (NO).");

                answer_verifiable[i] = int.Parse(Console.ReadLine());  //TEST THE LENGTHS OF THE SIDES OF THE SHAPE TO VERIFY THE CONDITION THAT THE SHAPE IS VERIFIABLE, AND STORE USER ANSWERS AND CORRECT ANSWERS IN ARRAYS.
                user_answer[i, 1] = answer_verifiable[i];
                string currentShape = generate_random_name_shap[i];
                switch (currentShape)
                {
                    case "Circle":
                        if (length_side[0] >= 4)
                        {
                            name_shap_verifiable[i] = 1;
                            correct_answer[i, 1] = name_shap_verifiable[i];
                        }
                        else
                        {
                            name_shap_verifiable[i] = 2;
                            correct_answer[i, 1] = name_shap_verifiable[i];
                        }
                        break;

                    case "Cylinder":
                        bool is_valid = true;
                        for (int y = 0; y < index; y++)
                        {
                            if (length_side[y] < 4)
                            {
                                is_valid = false;
                                break;
                            }
                        }
                        name_shap_verifiable[i] = is_valid ? 1 : 2;
                        correct_answer[i, 1] = name_shap_verifiable[i];
                        break;

                    case "Triangle":
                        is_valid = true;
                        for (int y = 0; y < index; y++)
                        {
                            int sum_of_other_sides = lengthes_sides_sum[i] - length_side[y];
                            if (length_side[y] > sum_of_other_sides)
                            {
                                is_valid = false;
                                break;
                            }
                        }
                        name_shap_verifiable[i] = is_valid ? 1 : 2;
                        correct_answer[i, 1] = name_shap_verifiable[i];
                        break;

                    case "Quadrilateral":
                        is_valid = true;
                        for (int y = 0; y < index; y++)
                        {
                            int sum_of_other_sides = lengthes_sides_sum[i] - length_side[y];
                            if (length_side[y] > sum_of_other_sides)
                            {
                                is_valid = false;
                                break;
                            }
                        }
                        name_shap_verifiable[i] = is_valid ? 1 : 2;
                        correct_answer[i, 1] = name_shap_verifiable[i];
                        break;

                    case "Pentagon":
                        is_valid = true;
                        for (int y = 0; y < index; y++)
                        {
                            int sum_of_other_sides = lengthes_sides_sum[i] - length_side[y];
                            if (length_side[y] > sum_of_other_sides)
                            {
                                is_valid = false;
                                break;
                            }
                        }
                        name_shap_verifiable[i] = is_valid ? 1 : 2;
                        correct_answer[i, 1] = name_shap_verifiable[i];
                        break;
                }

                // TESTING NAME SHAPE IF WAS ACTUAL NAME OR NOT, ENTER THE USER'S ANSWER, AND STORE USER ANSWERS AND CORRECT ANSWERS IN ARRAYS.

                Console.WriteLine("\nEnter 1 ===== If the previous name shape is the actual name (YES).\nEnter 2 ===== If the previous name shape isn't the actual name (NO).\"");
                answer_actual_name_shape[i] = int.Parse(Console.ReadLine());
                user_answer[i, 2] = answer_actual_name_shape[i];
                if (generate_random_name_shap[i] == generate_random_name_shap_test[i])
                {
                    actul_name_shape[i] = 1;
                    correct_answer[i, 2] = actul_name_shape[i];
                }
                else
                {
                    actul_name_shape[i] = 2;
                    correct_answer[i, 2] = actul_name_shape[i];
                }

            }
            //=====================================
            // 7. (B) USER ANSWER RATING 
            //=====================================

            for (int i = 0; i < number_of_questions; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((correct_answer[i, j] == user_answer[i, j]))
                    {
                        count++;
                    }
                }
                user_answer_rating[i] = count;
                count = 1;
            }

            //====================================================================================================
            //                                          SECTION 2:
            //====================================================================================================
            Boolean flag2 = true;
            while (flag2)
            {
                Console.WriteLine("\n---------------------------------------------------------------------------------\n");
                Console.WriteLine("\nEnter : 1---- View a rating of the shape you entered at the beginning of the game." +
                    "              \nEnter : 2---- View the generating shapes for all the questions raised." +
                    "              \nEnter : 3---- View the number of wrong answers (Fully)." +
                    "              \nEnter : 4---- View the number of correct answers (Fully)." +
                    "              \nEnter : 5---- View the number of relatively correct answers." +
                    "              \nEnter : 6---- View the user's answers to the questions, the correct answers that agree with each question, and is the user's answer completey corret?." +
                    "              \nEnter : quit--- to finished");
                string input = Console.ReadLine().ToLower();
                int input_number = 0;
                if (input == "quit")
                {
                    Console.WriteLine("//==================================================\n" +
                                                        "//      END THE GAME:\n" +
                                      "//==================================================");
                    flag2 = false;
                    break;
                }
                else
                {
                    input_number = int.Parse(input);
                    switch (input_number)
                    {
                        case 1:
                            rating_shape_entered_by_user(user_shape_name, number_of_sides, sides_length);
                            break;
                        case 2:
                            view_generate_shapes(number_of_questions, generate_random_name_shap_test);
                            break;
                        case 3:
                            view_number_wrong_answer(number_of_questions, user_answer_rating);
                            break;
                        case 4:
                            view_number_correct_answer(number_of_questions, user_answer_rating);
                            break;
                        case 5:
                            view_number_relatively_answer(number_of_questions, user_answer_rating);
                            break;
                        case 6:
                            view_users_answer(number_of_questions, user_answer, correct_answer, user_answer_rating);
                            break;
                        default:
                            Console.WriteLine("The text contains invalid values. Try again.");
                            break;
                    }
                }
            }

        }

        static void rating_shape_entered_by_user(string user_shape_name, int number_of_sides, int[] sides_length)
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
            int sides_length_sum = 0;

            Console.WriteLine("Name shape : " + user_shape_name + " is Accept");

            for (int i = 0; i < number_of_sides; i++)
            {
                sides_length_sum += sides_length[i];
            }

            switch (user_shape_name)
            {
                case "circle":
                    if (number_of_sides == 1)
                    {
                        Console.WriteLine("Accept Number of sides for shape :" + number_of_sides);
                    }
                    else
                    {
                        Console.WriteLine("Unaccept Number of sides for shape :" + number_of_sides);
                    }
                    break;

                case "cylinder":
                    if (number_of_sides == 2)
                    {
                        Console.WriteLine("Accept Number of sides for shape :" + number_of_sides);
                    }
                    else
                    {
                        Console.WriteLine("Unaccept Number of sides for shape :" + number_of_sides);
                    }
                    break;
                case "triangle":
                    if (number_of_sides == 3)
                    {
                        Console.WriteLine("Accept Number of sides for shape :" + number_of_sides);
                    }
                    else
                    {
                        Console.WriteLine("Unaccept Number of sides for shape :" + number_of_sides);
                    }
                    break;
                case "quadrilateral":
                    if (number_of_sides == 4)
                    {
                        Console.WriteLine("Accept Number of sides for shape :" + number_of_sides);
                    }
                    else
                    {
                        Console.WriteLine("Unaccept Number of sides for shape :" + number_of_sides);
                    }
                    break;
                case "pentagon":
                    if (number_of_sides == 5)
                    {
                        Console.WriteLine("Accept Number of sides for shape :" + number_of_sides);
                    }
                    else
                    {
                        Console.WriteLine("Unaccept Number of sides for shape :" + number_of_sides);
                    }
                    break;
            }

            switch (user_shape_name)
            {
                case "circle":
                    if (sides_length[0] >= 4)
                    {
                        Console.WriteLine("Accept accprding to the rule Number of sides for shape.");
                    }
                    else
                    {
                        Console.WriteLine("Unaccept accprding to the rule Number of sides for shape.");
                    }
                    break;

                case "cylinder":
                    Boolean is_valid = true;
                    for (int y = 0; y < number_of_sides; y++)
                    {
                        if (sides_length[y] < 4)
                        {
                            is_valid = false;
                            break;
                        }
                    }
                    if (is_valid == false)
                    {
                        Console.WriteLine("Unaccept accprding to the rule Number of sides for shape.");
                    }
                    else
                    {
                        Console.WriteLine("Accept accprding to the rule Number of sides for shape.");
                    }
                    break;

                case "triangle":
                    is_valid = true;
                    for (int y = 0; y < number_of_sides; y++)
                    {
                        int sum_of_other_sides = sides_length_sum - sides_length[y];
                        if (sides_length[y] > sum_of_other_sides)
                        {
                            is_valid = false;
                            break;
                        }
                    }
                    if (is_valid == false)
                    {
                        Console.WriteLine("Unaccept accprding to the rule Number of sides for shape.");
                    }
                    else
                    {
                        Console.WriteLine("Accept accprding to the rule Number of sides for shape.");
                    }
                    break;

                case "quadrilateral":
                    is_valid = true;
                    for (int y = 0; y < number_of_sides; y++)
                    {
                        int sum_of_other_sides = sides_length_sum - sides_length[y];
                        if (sides_length[y] > sum_of_other_sides)
                        {
                            is_valid = false;
                            break;
                        }
                    }
                    if (is_valid == false)
                    {
                        Console.WriteLine("Unaccept accprding to the rule Number of sides for shape.");
                    }
                    else
                    {
                        Console.WriteLine("Accept accprding to the rule Number of sides for shape.");
                    }
                    break;

                case "pentagon":
                    is_valid = true;
                    for (int y = 0; y < number_of_sides; y++)
                    {
                        int sum_of_other_sides = sides_length_sum - sides_length[y];
                        if (sides_length[y] > sum_of_other_sides)
                        {
                            is_valid = false;
                            break;
                        }
                    }
                    if (is_valid == false)
                    {
                        Console.WriteLine("Unaccept accprding to the rule Number of sides for shape.");
                    }
                    else
                    {
                        Console.WriteLine("Accept accprding to the rule Number of sides for shape.");
                    }
                    break;
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");

        }

        static void view_generate_shapes(int number_of_questions, string[] generate_random_name_shap_test)
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
            Console.Write("Questions generating shapes : ");
            for (int i = 0; i < number_of_questions; i++)
            {
                Console.Write("[" + generate_random_name_shap_test[i] + "] ");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
        }

        static void view_number_wrong_answer(int number_of_questions, int[] user_answer_rating)
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
            int count1 = 0;
            for (int i = 0; i < number_of_questions; i++)
            {
                if (user_answer_rating[i] == 1)
                {
                    count1++;
                }
            }
            Console.WriteLine("Number wrong answer is : " + count1);
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
        }

        static void view_number_correct_answer(int number_of_questions, int[] user_answer_rating)
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
            int count1 = 0;
            for (int i = 0; i < number_of_questions; i++)
            {
                if (user_answer_rating[i] == 4)
                {
                    count1++;
                }
            }
            Console.WriteLine("Number correct answer is : " + count1);
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
        }

        static void view_number_relatively_answer(int number_of_questions, int[] user_answer_rating)
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
            int count1 = 0;
            for (int i = 0; i < number_of_questions; i++)
            {
                if ((user_answer_rating[i] == 2) || (user_answer_rating[i] == 3))
                {
                    count1++;
                }
            }
            Console.WriteLine("Number relatively answer is : " + count1);
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
        }

        static void view_users_answer(int number_of_questions, int[,] user_answer, int[,] correct_answer, int[] user_answer_rating)
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
            for (int i = 0; i < number_of_questions; i++)
            {
                int q = i + 1;
                Console.WriteLine("\n====Question" + q + ":====\n");
                Console.WriteLine("\nuser_answer :");//USER ANSWER FOR Q1 , Q2 ,Q3 ,...
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(user_answer[i, j] + "\t");
                }
                Console.WriteLine("\ncorrect_answer :");//CORRECT ANSWER FOR Q1 , Q2 ,Q3 ,...
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(correct_answer[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int count1 = 0;
            for (int i = 0; i < number_of_questions; i++)
            {
                if (user_answer_rating[i] == 4)//CORRECT ANSWER FOR ALL QUESTION
                {
                    count1++;
                }
            }
            if (count1 == number_of_questions)
            {
                Console.WriteLine("The user's answer completey corret");
            }
            else
            {
                Console.WriteLine("The user's answer is not completey corret");
            }

        }

    }
}
