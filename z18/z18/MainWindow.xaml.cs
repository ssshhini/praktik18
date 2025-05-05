
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace z18
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SolvePatternTasks();
            SolveTableTasks();
            SolveOptionTasks();
        }

        private void SolvePatternTasks()
        {
           
            AddSolution("Задача 1", SolvePatternTask(new[] { "011", "010", "111", "010", "110", "110", "011" }), PatternTasksPanel);

            
            AddSolution("Задача 2", SolvePatternTask(new[] { "111", "011", "110", "011", "010", "110", "110", "011" }), PatternTasksPanel);

            
            AddSolution("Задача 3", SolvePatternTask(new[] { "111", "010", "011", "110", "011", "110", "011" }), PatternTasksPanel);

            
            AddSolution("Задача 4", SolvePatternTask(new[] { "010", "011", "110", "011", "111", "011" }), PatternTasksPanel);
        }

        private void SolveTableTasks()
        {
            
            string[] task7 = { "7", "211", "112", "a", "012", "b", "110", "210", "011", "" };
            AddSolution("Задача 7", SolveTableTask(task7), TableTasksPanel);

            string[] task8 = { "8", "211", "010", "a", "112", "b", "011", "111", "210", "" };
            AddSolution("Задача 8", SolveTableTask(task8), TableTasksPanel);

            string[] task9 = { "9", "112", "112", "a", "012", "b", "211", "" };
            AddSolution("Задача 9", SolveTableTask(task9), TableTasksPanel);

            string[] task10 = { "10", "011", "011", "210", "112", "a" };
            AddSolution("Задача 10", SolveTableTask(task10), TableTasksPanel);

            string[] task11 = { "11", "110", "010", "a", "011", "b", "110", "c", "011", "" };
            AddSolution("Задача 11", SolveTableTask(task11), TableTasksPanel);

            string[] task12 = { "12", "011", "011", "a", "111", "c", "010", "110", "111", "" };
            AddSolution("Задача 12", SolveTableTask(task12), TableTasksPanel);

            string[] task13 = { "13", "110", "010", "a", "111", "b", "110", "c", "011", "" };
            AddSolution("Задача 13", SolveTableTask(task13), TableTasksPanel);

            string[] task14 = { "14", "010", "010", "a", "111", "b", "111", "" };
            AddSolution("Задача 14", SolveTableTask(task14), TableTasksPanel);
        }

        private void SolveOptionTasks()
        {
            
            AddSolution("Задача 23", SolveOptionTask(new[] { "a. 0.11", "1.11", "b. 0.11", "1.10", "c. 0.10", "1.10" }), OptionTasksPanel);
            AddSolution("Задача 24", SolveOptionTask(new[] { "a. 1.10", "0.11", "1.11", "b. 0.11", "1.11", "c. 0.10", "1.11" }), OptionTasksPanel);
            AddSolution("Задача 25", SolveOptionTask(new[] { "a. 0.11", "1.11", "b. 0.11", "1.10", "c. 0.10", "1.10" }), OptionTasksPanel);
            AddSolution("Задача 26", SolveOptionTask(new[] { "a. 1.10", "0.11", "b. 0.11", "1.11", "c. 0.10", "1.10" }), OptionTasksPanel);
            AddSolution("Задача 27", SolveOptionTask(new[] { "a. 1.11", "0.11", "b. 0.11", "c. 0.11" }), OptionTasksPanel);
            AddSolution("Задача 28", SolveOptionTask(new[] { "a. 1.10", "0.11", "b. 0.11", "c. 0.10", "d. 0.11" }), OptionTasksPanel);
        }

        private string SolvePatternTask(string[] patterns)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Анализ бинарных паттернов:");

            int totalOnes = 0;
            int totalZeros = 0;
            int[] columnSums = new int[3];

            foreach (var pattern in patterns)
            {
                sb.AppendLine(pattern);
                for (int i = 0; i < 3; i++)
                {
                    if (pattern[i] == '1')
                    {
                        totalOnes++;
                        columnSums[i]++;
                    }
                    else
                    {
                        totalZeros++;
                    }
                }
            }

            sb.AppendLine("\nСтатистика:");
            sb.AppendLine($"Всего 1: {totalOnes}");
            sb.AppendLine($"Всего 0: {totalZeros}");
            sb.AppendLine("Суммы по столбцам: " + string.Join(", ", columnSums));

           
            int maxCol = Array.IndexOf(columnSums, columnSums.Max()) + 1;
            sb.AppendLine($"Доминирующий столбец: {maxCol} (с максимальным числом 1)");

            return sb.ToString();
        }

        private string SolveTableTask(string[] tableData)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Анализ табличных данных:");

            
            string taskNumber = tableData[0];
            sb.AppendLine($"Задача {taskNumber}:");

           
            for (int i = 1; i < tableData.Length; i += 2)
            {
                if (i + 1 < tableData.Length)
                {
                    string left = tableData[i];
                    string right = tableData[i + 1];

                    if (!string.IsNullOrEmpty(left) && !string.IsNullOrEmpty(right))
                    {
                        sb.AppendLine($"{left.PadRight(5)} → {right}");
                    }
                }
            }

            
            if (tableData.Length > 3)
            {
                sb.AppendLine("\nВывод: " + tableData[3]);
            }

            return sb.ToString();
        }

        private string SolveOptionTask(string[] options)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Анализ вариантов:");

            string currentGroup = "";
            foreach (var option in options)
            {
                if (option.Contains("."))
                {
                    currentGroup = option.Split('.')[0];
                    sb.AppendLine(option);
                }
                else
                {
                    sb.AppendLine($"   {currentGroup} продолжение: {option}");
                }
            }

           
            var bestOption = options.FirstOrDefault(o => o.Contains("1.11")) ?? options[0];
            sb.AppendLine("\nРекомендуемый вариант: " + bestOption.Split('.')[0].Trim());

            return sb.ToString();
        }

        private void AddSolution(string title, string content, StackPanel panel)
        {
            var border = new Border
            {
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5),
                Margin = new Thickness(0, 0, 0, 10),
                Background = Brushes.WhiteSmoke,
                Padding = new Thickness(10)
            };

            var stack = new StackPanel();

            var titleBlock = new TextBlock
            {
                Text = title,
                FontWeight = FontWeights.Bold,
                FontSize = 14,
                Margin = new Thickness(0, 0, 0, 5),
                Foreground = Brushes.DarkBlue
            };

            var contentBlock = new TextBlock
            {
                Text = content,
                TextWrapping = TextWrapping.Wrap,
                FontFamily = new FontFamily("Consolas"),
                FontSize = 12
            };

            stack.Children.Add(titleBlock);
            stack.Children.Add(contentBlock);
            border.Child = stack;
            panel.Children.Add(border);
        }
    }
}