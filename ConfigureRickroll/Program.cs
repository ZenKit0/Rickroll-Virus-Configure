using System.IO;
using System.Text.Json;
using Microsoft.Win32.TaskScheduler;
using ASquare.WindowsTaskScheduler;
using ASquare.WindowsTaskScheduler.Models;

namespace ConfigureRickroll {
    class Program {
        private static string path;
        static void Main(string[] args) {
            string jsonText = File.ReadAllText("conf.json");
            path = JsonSerializer.Deserialize<RickRollPath>(jsonText).Path;

            TaskDefinition td = TaskService.Instance.NewTask();
            LogonTrigger dt = new LogonTrigger();
            dt.Repetition.Interval = System.TimeSpan.FromMinutes(1);

            td.Triggers.Add(dt);
            td.Actions.Add(path);

            TaskService.Instance.RootFolder.RegisterTaskDefinition("Rickroll", td);

        }
    }

    class RickRollPath {
        public string Path { get; set; }
    }
}
