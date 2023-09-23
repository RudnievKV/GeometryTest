using GeometryTest.Models.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeometryTest.Models
{
    public class GeometryTestData
    {
        private IList<BaseShape> _data = new List<BaseShape>();

        public GeometryTestData()
        {
        }
        #region Main Functions
        public string OutputAllFigures()
        {
            var stringBuilder = new StringBuilder();
            foreach (var shape in _data)
            {
                switch (shape)
                {
                    case Circle circle:
                        {
                            stringBuilder.AppendLine($"Circle - radius: {circle.Radius} - Perimeter: {circle.Perimeter} - Area: {circle.Area}");
                            break;
                        }
                    case Square square:
                        {
                            stringBuilder.AppendLine($"Square - side: {square.Side} - Perimeter: {square.Perimeter} - Area: {square.Area}");
                            break;
                        }
                    case Rectangle rectangle:
                        {
                            stringBuilder.AppendLine($"Rectangle - width: {rectangle.Width}, height: {rectangle.Height} - " +
                                $"Perimeter: {rectangle.Perimeter} - Area: {rectangle.Area}");
                            break;
                        }
                    case Triangle triangle:
                        {
                            stringBuilder.AppendLine($"Triangle - first side: {triangle.FirstSide}" +
                                $", second side: {triangle.SecondSide}, third side: {triangle.ThirdSide} - " +
                                $"Perimeter: {triangle.Perimeter} - Area: {triangle.Area}");
                            break;
                        }
                }
            }
            return stringBuilder.ToString();
        }

        public void PerformTransformation()
        {
            var newData = new List<BaseShape>();

            foreach (var shape in _data)
            {
                switch (shape)
                {
                    case Circle circle:
                        {
                            var newSquare = new Square(circle.Radius);
                            newData.Add(newSquare);
                            break;
                        }
                    case Square square:
                        {
                            var newCircle = new Circle(square.Side);
                            newData.Add(newCircle);
                            break;
                        }
                    case Rectangle rectangle:
                        {
                            var newTriangle = new Triangle(rectangle.Width, rectangle.Height, rectangle.Height + rectangle.Width);
                            newData.Add(newTriangle);
                            break;
                        }
                    case Triangle triangle:
                        {
                            var newRectangle = new Rectangle(triangle.FirstSide, triangle.SecondSide);
                            newData.Add(newRectangle);
                            break;
                        }
                }
            }
            _data = newData;
        }

        public string SaveToFile(string fileName)
        {
            try
            {
                var serializeOptions = new JsonSerializerOptions() { WriteIndented = true };
                serializeOptions.Converters.Add(new FigureConverter(new Type[] { typeof(Circle), typeof(Rectangle), typeof(Square), typeof(Triangle) }));
                string strJson = JsonSerializer.Serialize(_data, serializeOptions);


                string folder = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = folder + fileName + ".txt";


                File.WriteAllText(fullPath, strJson);

                return "Saving completed successfully.";
            }
            catch
            {
                return $"Could not save shapes to file {fileName}.";
            }
        }

        public string ReadFromFile(string fileName)
        {
            try
            {
                string folder = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = folder + fileName + ".txt";

                string json = File.ReadAllText(fullPath);

                var serializeOptions = new JsonSerializerOptions();
                serializeOptions.Converters.Add(new FigureConverter(new Type[] { typeof(Circle), typeof(Rectangle), typeof(Square), typeof(Triangle) }));
                var deserializedFigures = JsonSerializer.Deserialize<List<BaseShape>>(json, serializeOptions);

                _data.Clear();

                if (deserializedFigures is not null)
                {
                    _data = deserializedFigures;
                    foreach (var shape in _data)
                    {
                        switch (shape)
                        {
                            case Circle circle:
                                {
                                    _data.Add(circle);
                                    break;
                                }
                            case Square square:
                                {
                                    _data.Add(square);
                                    break;
                                }
                            case Rectangle rectangle:
                                {
                                    _data.Add(rectangle);
                                    break;
                                }
                            case Triangle triangle:
                                {
                                    _data.Add(triangle);
                                    break;
                                }
                        }
                    }
                }


                return "All shapes have been uploaded.";
            }
            catch
            {
                return $"Could not upload shapes from file {fileName}.";
            }
        }
        #endregion

        #region Add Shapes
        public void AddCircle(Circle circle)
        {
            _data.Add(circle);
        }
        public void AddSquare(Square square)
        {
            _data.Add(square);
        }
        public void AddRectangle(Rectangle rectangle)
        {
            _data.Add(rectangle);
        }
        public void AddTriangle(Triangle triangle)
        {
            _data.Add(triangle);
        }
        #endregion

        #region Delete Shapes
        public void DeleteAllCircles()
        {
            foreach (var figure in _data)
            {
                if (figure is Circle)
                {
                    _data.Remove(figure);
                }
            }
        }
        public void DeleteAllSquares()
        {
            foreach (var figure in _data)
            {
                if (figure is Square)
                {
                    _data.Remove(figure);
                }
            }
        }
        public void DeleteAllRectangles()
        {
            foreach (var figure in _data)
            {
                if (figure is Rectangle)
                {
                    _data.Remove(figure);
                }
            }
        }
        public void DeleteAllTriangles()
        {
            foreach (var figure in _data)
            {
                if (figure is Triangle)
                {
                    _data.Remove(figure);
                }
            }
        }
        #endregion

    }
}
