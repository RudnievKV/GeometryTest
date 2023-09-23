using GeometryTest.Models;
using GeometryTest.Models.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTest
{
    public class GeometryTest
    {
        private readonly GeometryTestData GeometryTestData;
        public GeometryTest()
        {
            GeometryTestData = new GeometryTestData();
        }
        public void Start()
        {
            string? userMainMenuInput;
            bool isUserMainMenuInputInvalid = false;
            while (true)
            {
                DisplayMainMenu();

                if (isUserMainMenuInputInvalid)
                {
                    Console.WriteLine();
                    Console.WriteLine("Input is invalid! Please enter number from 1 to 7.");
                    userMainMenuInput = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please select your desired operation by entering value below:");
                    userMainMenuInput = Console.ReadLine();
                }


                switch (userMainMenuInput)
                {
                    case "1":
                        {
                            isUserMainMenuInputInvalid = false;

                            AddShapes();

                            break;
                        }
                    case "2":
                        {
                            isUserMainMenuInputInvalid = false;

                            ViewAllShapes();

                            break;
                        }
                    case "3":
                        {
                            isUserMainMenuInputInvalid = false;

                            DeleteShapes();

                            break;
                        }
                    case "4":
                        {
                            isUserMainMenuInputInvalid = false;

                            PerformTransformation();

                            break;
                        }
                    case "5":
                        {
                            isUserMainMenuInputInvalid = false;

                            SaveShapes();

                            break;
                        }
                    case "6":
                        {
                            isUserMainMenuInputInvalid = false;

                            UploadShapes();

                            break;
                        }
                    case "7":
                        {
                            return;
                        }
                    default:
                        {
                            isUserMainMenuInputInvalid = true;
                            break;
                        }
                }
            }
        }
        #region Main Functions
        private void AddShapes()
        {

            bool isUserAddMenuInputInvalid = false;

            bool done = false;
            string? userAddMenuInput;

            while (!done)
            {
                DisplayAddMenu();

                if (isUserAddMenuInputInvalid)
                {
                    Console.WriteLine();
                    Console.WriteLine("Input is invalid! Please enter number from 1 to 5.");
                    userAddMenuInput = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please select your desired operation by entering value below:");
                    userAddMenuInput = Console.ReadLine();
                }



                switch (userAddMenuInput)
                {
                    case "1":
                        {
                            isUserAddMenuInputInvalid = false;

                            DisplayAddTriangleMenu();
                            AddTriangleFromConsole();

                            break;
                        }
                    case "2":
                        {
                            isUserAddMenuInputInvalid = false;

                            DisplayAddRectangleMenu();
                            AddRectangleFromConsole();

                            break;
                        }
                    case "3":
                        {
                            isUserAddMenuInputInvalid = false;

                            DisplayAddSquareMenu();
                            AddSquareFromConsole();

                            break;
                        }
                    case "4":
                        {
                            isUserAddMenuInputInvalid = false;

                            DisplayAddCircleMenu();
                            AddCircleFromConsole();

                            break;
                        }
                    case "5":
                        {
                            done = true;
                            break;
                        }
                    default:
                        {
                            isUserAddMenuInputInvalid = true;
                            break;
                        }
                }
            }
        }
        private void ViewAllShapes()
        {
            string allShapes = GeometryTestData.OutputAllFigures();

            Console.Clear();
            Console.WriteLine("View all shapes menu:");
            Console.Write(allShapes);
            Console.WriteLine();
            Console.WriteLine("Press any button to return to previous menu...");
            Console.ReadKey();
        }
        private void DeleteShapes()
        {
            bool isUserDeleteMenuInputInvalid = false;

            bool done = false;
            string? userAddMenuInput;

            while (!done)
            {
                DisplayDeleteMenu();

                if (isUserDeleteMenuInputInvalid)
                {
                    Console.WriteLine();
                    Console.WriteLine("Input is invalid! Please enter number from 1 to 5.");
                    userAddMenuInput = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please select your desired operation by entering value below:");
                    userAddMenuInput = Console.ReadLine();
                }



                switch (userAddMenuInput)
                {
                    case "1":
                        {
                            isUserDeleteMenuInputInvalid = false;

                            GeometryTestData.DeleteAllTriangles();

                            break;
                        }
                    case "2":
                        {
                            isUserDeleteMenuInputInvalid = false;

                            GeometryTestData.DeleteAllRectangles();

                            break;
                        }
                    case "3":
                        {
                            isUserDeleteMenuInputInvalid = false;

                            GeometryTestData.DeleteAllSquares();

                            break;
                        }
                    case "4":
                        {
                            isUserDeleteMenuInputInvalid = false;

                            GeometryTestData.DeleteAllCircles();

                            break;
                        }
                    case "5":
                        {
                            done = true;
                            break;
                        }
                    default:
                        {
                            isUserDeleteMenuInputInvalid = true;
                            break;
                        }
                }
            }
        }
        private void PerformTransformation()
        {
            GeometryTestData.PerformTransformation();

            Console.Clear();
            Console.WriteLine("Perform the transformation menu:");
            Console.WriteLine("Transformation completed");
            Console.WriteLine();
            Console.WriteLine("Press any button to return to previous menu...");
            Console.ReadKey();
        }
        private void SaveShapes()
        {
            bool isUserLoadMenuInputInvalid = false;

            string? userSaveMenuInput;

            while (true)
            {
                DisplaySaveMenu();

                if (isUserLoadMenuInputInvalid)
                {
                    Console.WriteLine();
                    Console.WriteLine("Input is invalid! Please enter valid file name");
                    userSaveMenuInput = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("To save shapes into file, enter your desired file name below:");
                    userSaveMenuInput = Console.ReadLine();
                }


                if (userSaveMenuInput is not null && userSaveMenuInput.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
                {
                    isUserLoadMenuInputInvalid = false;
                    string result = GeometryTestData.SaveToFile(userSaveMenuInput);
                    Console.WriteLine(result);
                    Console.WriteLine();
                    Console.WriteLine("Press any button to return to previous menu...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    isUserLoadMenuInputInvalid = true;
                }
            }
        }

        private void UploadShapes()
        {
            bool isUserUploadMenuInputInvalid = false;

            string? userUploadMenuInput;

            while (true)
            {
                DisplayLoadMenu();

                if (isUserUploadMenuInputInvalid)
                {
                    Console.WriteLine();
                    Console.WriteLine("Input is invalid! Please enter valid file name");
                    userUploadMenuInput = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("To load shapes from file, enter files name below:");
                    userUploadMenuInput = Console.ReadLine();
                }

                if (userUploadMenuInput is not null && userUploadMenuInput.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
                {
                    isUserUploadMenuInputInvalid = false;
                    var result = GeometryTestData.ReadFromFile(userUploadMenuInput);
                    Console.WriteLine(result);
                    Console.WriteLine();
                    Console.WriteLine("Press any button to return to previous menu...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    isUserUploadMenuInputInvalid = true;
                }
            }
        }
        #endregion


        #region Menus
        private void DisplayLoadMenu()
        {
            Console.Clear();
            Console.WriteLine("Upload menu: ");
        }
        private void DisplaySaveMenu()
        {
            Console.Clear();
            Console.WriteLine("Save menu: ");

        }
        private void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Main menu: ");
            Console.WriteLine("1. Add a new shape.");
            Console.WriteLine("2. View all shapes.");
            Console.WriteLine("3. Delete shapes.");
            Console.WriteLine("4. Perform the transformation.");
            Console.WriteLine("5. Save shapes.");
            Console.WriteLine("6. Upload shapes.");
            Console.WriteLine("7. Exit.");
        }
        private void DisplayAddMenu()
        {
            Console.Clear();
            Console.WriteLine("Add menu: ");
            Console.WriteLine("1. Triangle.");
            Console.WriteLine("2. Rectangle.");
            Console.WriteLine("3. Square.");
            Console.WriteLine("4. Circle.");
            Console.WriteLine("5. Cancel.");
        }
        private void DisplayDeleteMenu()
        {
            Console.Clear();
            Console.WriteLine("Delete menu: ");
            Console.WriteLine("1. Triangle.");
            Console.WriteLine("2. Rectangle.");
            Console.WriteLine("3. Square.");
            Console.WriteLine("4. Circle.");
            Console.WriteLine("5. Cancel.");
        }
        private void DisplayAddTriangleMenu()
        {
            Console.Clear();
            Console.WriteLine("Triangle adding menu:");
            Console.WriteLine();
            Console.WriteLine("To cancel and return to previous menu enter 0");
            Console.WriteLine("Enter three sides separately by pressing enter after each.");
            Console.WriteLine();
        }
        private void DisplayAddRectangleMenu()
        {
            Console.Clear();
            Console.WriteLine("Rectangle adding menu:");
            Console.WriteLine();
            Console.WriteLine("To cancel and return to previous menu enter 0");
            Console.WriteLine("Enter height and width separately by pressing enter after each.");
            Console.WriteLine();

        }
        private void DisplayAddSquareMenu()
        {
            Console.Clear();
            Console.WriteLine("Square adding menu:");
            Console.WriteLine();
            Console.WriteLine("To cancel and return to previous menu enter 0");
            Console.WriteLine("Enter side value by pressing enter after typing.");
            Console.WriteLine();
        }
        private void DisplayAddCircleMenu()
        {
            Console.Clear();
            Console.WriteLine("Circle adding menu:");
            Console.WriteLine();
            Console.WriteLine("To cancel and return to previous menu enter 0");
            Console.WriteLine("Enter radius by pressing enter after typing.");
            Console.WriteLine();
        }
        #endregion


        #region AddFiguresFromConsole
        private void AddCircleFromConsole()
        {
            double radius;

            while (true)
            {

                Console.WriteLine("Enter radius value:");
                var isInputValid = double.TryParse(Console.ReadLine(), out radius);
                if (radius != 0 && isInputValid)
                {
                    break;
                }
                else if (radius == 0 && isInputValid)
                {
                    return;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Input is invalid! Please re-enter radius.");
                }

            }

            var newCircle = new Circle(radius);
            GeometryTestData.AddCircle(newCircle);
        }
        private void AddSquareFromConsole()
        {
            double side;

            while (true)
            {

                Console.WriteLine("Enter side value:");
                var isInputValid = double.TryParse(Console.ReadLine(), out side);
                if (side != 0 && isInputValid)
                {
                    break;
                }
                else if (side == 0 && isInputValid)
                {
                    return;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Input is invalid! Please re-enter side value.");
                }

            }


            var newSquare = new Square(side);
            GeometryTestData.AddSquare(newSquare);
        }
        private void AddRectangleFromConsole()
        {
            double height;
            double width;

            while (true)
            {

                Console.WriteLine("Enter height value:");
                var isInputValid = double.TryParse(Console.ReadLine(), out height);
                if (height != 0 && isInputValid)
                {
                    break;
                }
                else if (height == 0 && isInputValid)
                {
                    return;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Input is invalid! Please re-enter height value.");
                }

            }
            while (true)
            {

                Console.WriteLine("Enter width value:");
                var isInputValid = double.TryParse(Console.ReadLine(), out width);
                if (width != 0 && isInputValid)
                {
                    break;
                }
                else if (width == 0 && isInputValid)
                {
                    return;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Input is invalid! Please re-enter width value.");
                }

            }

            var newRectangle = new Models.Figures.Rectangle(height, width);
            GeometryTestData.AddRectangle(newRectangle);
        }
        private void AddTriangleFromConsole()
        {
            double firstSide;
            double secondSide;
            double thirdSide;
            bool isTriangleWrong = true;
            while (isTriangleWrong)
            {
                while (true)
                {

                    Console.WriteLine("Enter first sides value:");
                    var isInputValid = double.TryParse(Console.ReadLine(), out firstSide);
                    if (firstSide != 0 && isInputValid)
                    {
                        break;
                    }
                    else if (firstSide == 0 && isInputValid)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Input is invalid! Please re-enter first sides value.");
                    }

                }
                while (true)
                {

                    Console.WriteLine("Enter second sides value:");
                    var isInputValid = double.TryParse(Console.ReadLine(), out secondSide);
                    if (secondSide != 0 && isInputValid)
                    {
                        break;
                    }
                    else if (secondSide == 0 && isInputValid)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Input is invalid! Please re-enter second sides value.");
                    }

                }
                while (true)
                {

                    Console.WriteLine("Enter third sides value:");
                    var isInputValid = double.TryParse(Console.ReadLine(), out thirdSide);
                    if (thirdSide != 0 && isInputValid)
                    {
                        break;
                    }
                    else if (thirdSide == 0 && isInputValid)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Input is invalid! Please re-enter third sides value.");
                    }

                }

                // Check if values are correct
                if (thirdSide >= firstSide + secondSide
                    || secondSide >= firstSide + thirdSide
                    || firstSide >= secondSide + thirdSide)
                {
                    Console.WriteLine("Triangle can not be constructed! Please start over.");
                    Console.WriteLine();
                }
                else
                {
                    // values are correct
                    var newTriangle = new Triangle(firstSide, secondSide, thirdSide);
                    GeometryTestData.AddTriangle(newTriangle);
                    isTriangleWrong = false;
                }
            }
        }
        #endregion
    }
}
