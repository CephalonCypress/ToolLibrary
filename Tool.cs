using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ToolLibrary {
    public class Tool : iTool, IComparable<Tool> {
        Hashtable toolHT = new Hashtable();
        SortedDictionary<string, string> toolSD = new SortedDictionary<string, string>();
        private void toolTypeInitialiser()
        {
            toolSD.Add("Line Trimmer", "Gardening");
            toolSD.Add("Lawn Mowers", "Gardening");
            toolSD.Add("Hand Tools", "Gardening");
            toolSD.Add("Wheelbarrows", "Gardening");
            toolSD.Add("Garden Power Tools", "Gardening");
            toolSD.Add("Scrapers", "Flooring");
            toolSD.Add("Floor Lasers", "Flooring");
            toolSD.Add("Floor Levelling Tools", "Flooring");
            toolSD.Add("Floor Levelling Materials", "Flooring");
            toolSD.Add("Floor Hand Tools", "Flooring");
            toolSD.Add("Tiling Tools", "Flooring");
            toolSD.Add("Fencing Hand Tools", "Fencing");
            toolSD.Add("Electric Fencing", "Fencing");
            toolSD.Add("Steel Fencing Tools", "Fencing");
            toolSD.Add("Power Tools", "Fencing");
            toolSD.Add("Fencing Accessories", "Fencing");
            toolSD.Add("Distance Tools", "Measuring");
            toolSD.Add("Laser Measurer", "Measuring");
            toolSD.Add("Measuring Jugs", "Measuring");
            toolSD.Add("Temperature & Humidity Tools", "Measuring");
            toolSD.Add("Levelling Tools", "Measuring");
            toolSD.Add("Markers", "Measuring");
            toolSD.Add("Draining", "Cleaning");
            toolSD.Add("Car Cleaning", "Cleaning");
            toolSD.Add("Vacuum", "Cleaning");
            toolSD.Add("Pressure Cleaners", "Cleaning");
            toolSD.Add("Pool Cleaning", "Cleaning");
            toolSD.Add("Floor Cleaning", "Cleaning");
            toolSD.Add("Sanding Tools", "Painting");
            toolSD.Add("Brushes", "Painting");
            toolSD.Add("Rollers", "Painting");
            toolSD.Add("Paint Removal Tools", "Painting");
            toolSD.Add("Paint Scrapers", "Painting");
            toolSD.Add("Sprayers", "Painting");
            toolSD.Add("Voltage Tester", "Electronic");
            toolSD.Add("Oscilloscopes", "Electronic");
            toolSD.Add("Thermal Imaging", "Electronic");
            toolSD.Add("Data Test Tool", "Electronic");
            toolSD.Add("Insulation Testers", "Electronic");
            toolSD.Add("Test Equipment", "Electricity");
            toolSD.Add("Safety Equipment", "Electricity");
            toolSD.Add("Basic Hand Tools", "Electricity");
            toolSD.Add("Circuit Protection", "Electricity");
            toolSD.Add("Cable Tools", "Electricity");
            toolSD.Add("Jacks", "Automotive");
            toolSD.Add("Air Compressors", "Automotive");
            toolSD.Add("Battery Chargers", "Automotive");
            toolSD.Add("Socket Tools", "Automotive");
            toolSD.Add("Braking", "Automotive");
            toolSD.Add("Drivetrain", "Automotive");
        }

        public enum toolCategory
        {
            Gardening,
            Flooring,
            Fencing,
            Measuring,
            Cleaning,
            Painting,
            Electronic,
            Electricity,
            Automotive
        }
        private toolCategory category;
        public toolCategory Category
        {
            get { return category; }
            set { category = value; }
        }
        public enum toolType {
            lineTrimmers,
            lawnMowers,
            handTools,
            wheelbarrows,
            gardenPowerTools,
            scrapers,
            floorLasers,
            floorLevellingTools,
            floorLevellingMaterials,
            floorHandTools,
            tilingTools,
            fencingHandTools,
            electricFencing,
            steelFencingTools,
            powerTools,
            fencingAccessories,
            distanceTools,
            laserMeasurer,
            measuringJugs,
            temperatureHumidityTools,
            levelingTools,
            markers,
            draining,
            carCleaning,
            vacuum,
            pressureCleaners,
            poolCleaning,
            floorCleaning,
            sanding,
            brushes,
            rollers,
            paintRemoval,
            paintScrapers,
            sprayers,
            voltageTester,
            oscilloscopes,
            thermalImaging,
            dataTestTool,
            insulationTesters,
            testEquipment,
            safetyEquipment,
            basicHandTools,
            circuitProtection,
            cableTools,
            jacks,
            airCompressors,
            batteryChargers,
            socketTools,
            braking,
            drivetrain
        }
        private toolType type;
        public toolType Type {
            get { return type; }
            set { type = value; }
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int NoBorrowings { get; set; }
        public int timesBorrowed { get; set; }
        public MemberCollection GetBorrowers { get; }


        public Tool(toolCategory category, toolType toolType, String name, int quantity) {
            this.Category = category;
            this.Type = toolType;
            this.Name = name;
            this.Quantity = quantity;
            this.AvailableQuantity = quantity;
            this.timesBorrowed = 0;
        }

        public Tool(toolCategory category, toolType toolType, String name, int quantity, int availableQuantity, int timesBorrowed)
        {
            this.Category = category;
            this.Type = toolType;
            this.Name = name;
            this.Quantity = quantity;
            this.AvailableQuantity = quantity;
            this.timesBorrowed = 0;
        }

        public Tool(toolCategory category, toolType toolType, String name)
        {
            this.Category = category;
            this.Type = toolType;
            this.Name = name;
        }

        public Hashtable getHT()
        {
            return toolHT;
        }

        public SortedDictionary<string, string> getSD()
        {
            return toolSD;
        }

        public Tool() {
            toolTypeInitialiser();
        }

        public int CompareTo(Tool tool)
        {
            Tool another = (Tool)tool;
            if (this.category.CompareTo(another.category) < 0)
                return 1;
            else
                if (this.type.CompareTo(another.type) == 0)
                return this.category.CompareTo(another.type);
            else
                return 1;
        }

        //public int CompareTo(string other)
        //{
        //    throw new NotImplementedException();
        //}

        public void addBorrower(Member member)
        {
            
        }

        public void deleteBorrower(Member member)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

