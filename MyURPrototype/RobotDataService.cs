using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyURPrototype
{
    public class RobotDataService
    {
        private readonly UpdatesEmitter updatesEmitter = new UpdatesEmitter();
        private readonly List<RobotUpdate> robotUpdatesList;
        private CultureInfo cultureInfoUS = CultureInfo.GetCultureInfo("en-US");

        public RobotDataService()
        {
            robotUpdatesList = SeedData();
        }

        public void HandleRobotUpdate()
        {
            var robotUpdate = GetRandomRobotUpdate();
            robotUpdate.StatusChangedDate = DateTime.UtcNow.ToString("g", cultureInfoUS);

            updatesEmitter.Emit(robotUpdate);
        }

        private RobotUpdate GetRandomRobotUpdate()
        {
            var random = new Random();
            var index = random.Next(robotUpdatesList.Count);
            return robotUpdatesList[index];
        }

        private List<RobotUpdate> SeedData()
        {
            return new List<RobotUpdate>()
            {
                new RobotUpdate()
                {
                    Id = "000001",
                    Name = "Prod_cobot_1",
                    Model = "UR3",
                    InstalledDate = new DateTime(2018, 8, 13).ToString("d", cultureInfoUS),
                    Status = "ok",
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    CustomerId = "00001",
                    LocationId = "00392"
                },
                new RobotUpdate()
                {
                    Id = "000204",
                    Name = "Prod_cobot_4",
                    Model = "UR5e",
                    InstalledDate = new DateTime(2022, 7, 2).ToString("d", cultureInfoUS),
                    Status = "ok",
                    Note = "Eu scelerisque felis imperdiet proin fermentum leo vel orci.",
                    CustomerId = "00005",
                    LocationId = "00928"
                },
                new RobotUpdate()
                {
                    Id = "008932",
                    Name = "Terminator",
                    Model = "UR20",
                    InstalledDate = new DateTime(2022, 10, 27).ToString("d", cultureInfoUS),
                    Status = "ok",
                    Note = "Scelerisque eleifend donec pretium vulputate sapien nec sagittis.",
                    CustomerId = "00001",
                    LocationId = "00392"
                },
                new RobotUpdate()
                {
                    Id = "003000",
                    Name = "Iron Man",
                    Model = "UR16e",
                    InstalledDate = new DateTime(2021, 5, 12).ToString("d", cultureInfoUS),
                    Status = "repair_needed",
                    Note = "In cursus turpis massa tincidunt dui ut ornare lectus sit.",
                    CustomerId = "00023",
                    LocationId = "02736"
                },
                new RobotUpdate()
                {
                    Id = "000999",
                    Name = "Jarvis",
                    Model = "UR10",
                    InstalledDate = new DateTime(2020, 1, 2).ToString("d", cultureInfoUS),
                    Status = "repair_needed",
                    Note = "Erat nam at lectus urna duis convallis convallis tellus id.",
                    CustomerId = "00011",
                    LocationId = "00352"
                },
                new RobotUpdate()
                {
                    Id = "000333",
                    Name = "Karen",
                    Model = "UR10e",
                    InstalledDate = new DateTime(2020, 3, 3).ToString("d", cultureInfoUS),
                    Status = "protective_stop",
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    CustomerId = "00001",
                    LocationId = "00392"
                },
                new RobotUpdate()
                {
                    Id = "000029",
                    Name = "Ultron",
                    Model = "UR5",
                    InstalledDate = new DateTime(2021, 6, 2).ToString("d", cultureInfoUS),
                    Status = "protective_stop",
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    CustomerId = "00003",
                    LocationId = "00497"
                },
                new RobotUpdate()
                {
                    Id = "000007",
                    Name = "Prod_cobot_11",
                    Model = "UR3e",
                    InstalledDate = new DateTime(2021, 8, 15).ToString("d", cultureInfoUS),
                    Status = "ok",
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    CustomerId = "00001",
                    LocationId = "00392"
                },
                new RobotUpdate()
                {
                    Id = "000009",
                    Name = "Package_cobot_4",
                    Model = "UR10e",
                    InstalledDate = new DateTime(2019, 11, 13).ToString("d", cultureInfoUS),
                    Status = "ok",
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    CustomerId = "00222",
                    LocationId = "00334"
                },
                new RobotUpdate()
                {
                    Id = "000011",
                    Name = "Package_cobot_23",
                    Model = "UR5e",
                    InstalledDate = new DateTime(2022, 7, 22).ToString("d", cultureInfoUS),
                    Status = "repair_needed",
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    CustomerId = "00021",
                    LocationId = "03297"
                }
            };
        }
    }
}
