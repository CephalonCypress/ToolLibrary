using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ToolLibrary {
    public class Tool : iTool, IComparable<Tool> {
        Hashtable toolHT = new Hashtable();

        private void toolCategoryTypeInitialiser()
        {
            toolHT.Add("Line Trimmer", "Gardening");
            toolHT.Add("Lawn Mowers", "Gardening");
            toolHT.Add("Hand Tools", "Gardening");
            toolHT.Add("Wheelbarrows", "Gardening");
            toolHT.Add("Garden Power Tools", "Gardening");
            toolHT.Add("Scrapers", "Flooring");
            toolHT.Add("Floor Lasers", "Flooring");
            toolHT.Add("Floor Levelling Tools", "Flooring");
            toolHT.Add("Floor Hand Tools", "Flooring");
            toolHT.Add("Tiling Tools", "Flooring");
            toolHT.Add("Fencing Hand Tools", "Fencing");
            toolHT.Add("Electric Fencing", "Fencing");
            toolHT.Add("Steel Fencing Tools", "Fencing");
            toolHT.Add("Power Tools", "Fencing");
            toolHT.Add("Fencing Accessories", "Fencing");
            toolHT.Add("Distance Tools", "Measuring");
            toolHT.Add("Laser Measurer", "Measuring");
            toolHT.Add("Measuring Jugs", "Measuring");
            toolHT.Add("Temperature & Humidity Tools", "Measuring");
            toolHT.Add("Levelling Tools", "Measuring");
            toolHT.Add("Markers", "Measuring");
            toolHT.Add("Draining", "Cleaning");
            toolHT.Add("Car Cleaning", "Cleaning");
            toolHT.Add("Vacuum", "Cleaning");
            toolHT.Add("Pressure Cleaners", "Cleaning");
            toolHT.Add("Pool Cleaning", "Cleaning");
            toolHT.Add("Floor Cleaning", "Cleaning");
            toolHT.Add("Sanding Tools", "Painting");
            toolHT.Add("Brushes", "Painting");
            toolHT.Add("Rollers", "Painting");
            toolHT.Add("Paint Removal Tools", "Painting");
            toolHT.Add("Paint Scrapers", "Painting");
            toolHT.Add("Sprayers", "Painting");
            toolHT.Add("Voltage Tester", "Electronic");
            toolHT.Add("Oscilloscopes", "Electronic");
            toolHT.Add("Thermal Imaging", "Electronic");
            toolHT.Add("Data Test Tool", "Electronic");
            toolHT.Add("Insulation Testers", "Electronic");
            toolHT.Add("Test Equipment", "Electricity");
            toolHT.Add("Safety Equipment", "Electricity");
            toolHT.Add("Basic Hand Tools", "Electricity");
            toolHT.Add("Circuit Protection", "Electricity");
            toolHT.Add("Cable Tools", "Electricity");
            toolHT.Add("Jacks", "Automotive");
            toolHT.Add("Air Compressors", "Automotive");
            toolHT.Add("Battery Chargers", "Automotive");
            toolHT.Add("Socket Tools", "Automotive");
            toolHT.Add("Braking", "Automotive");
            toolHT.Add("Drivetrain", "Automotive");
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
        public MemberCollection GetBorrowers { get; }

        public Tool(toolCategory category, toolType toolType, String name, int quantity) {
            this.Category = category;
            this.Type = toolType;
            this.Name = name;
            this.Quantity = quantity;
        }

        public Hashtable getHT()
        {
            return toolHT;
        }

        public Tool() {
            toolCategoryTypeInitialiser();

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

