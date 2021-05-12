using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ToolLibrary {
    public class Tool : iTool {
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
        public enum toolCategory {
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
        public toolCategory Category {
            get { return category; }
            set { category = value; }
        }
        public enum toolType {
            lineTrimmers = toolCategory.Gardening,
            lawnMowers = toolCategory.Gardening,
            handTools = toolCategory.Gardening,
            wheelbarrows = toolCategory.Gardening,
            gardenPowerTools = toolCategory.Gardening,
            scrapers = toolCategory.Flooring,
            floorLasers = toolCategory.Flooring,
            floorLevellingTools = toolCategory.Flooring,
            floorLevellingMaterials = toolCategory.Flooring,
            floorHandTools = toolCategory.Flooring,
            tilingTools = toolCategory.Flooring,
            fencingHandTools = toolCategory.Fencing,
            electricFencing = toolCategory.Fencing,
            steelFencingTools = toolCategory.Fencing,
            powerTools = toolCategory.Fencing,
            fencingAccessories = toolCategory.Fencing,
            distanceTools = toolCategory.Measuring,
            laserMeasurer = toolCategory.Measuring,
            measuringJugs = toolCategory.Measuring,
            temperatureHumidityTools = toolCategory.Measuring,
            levelingTools = toolCategory.Measuring,
            markers = toolCategory.Measuring,
            draining = toolCategory.Cleaning,
            carCleaning = toolCategory.Cleaning,
            vacuum = toolCategory.Cleaning,
            pressureCleaners = toolCategory.Cleaning,
            poolCleaning = toolCategory.Cleaning,
            floorCleaning = toolCategory.Cleaning,
            sanding = toolCategory.Painting,
            brushes = toolCategory.Painting,
            rollers = toolCategory.Painting,
            paintRemoval = toolCategory.Painting,
            paintScrapers = toolCategory.Painting,
            sprayers = toolCategory.Painting,
            voltageTester = toolCategory.Electronic,
            oscilloscopes = toolCategory.Electronic,
            thermalImaging = toolCategory.Electronic,
            dataTestTool = toolCategory.Electronic,
            insulationTesters = toolCategory.Electronic,
            testEquipment = toolCategory.Electricity,
            safetyEquipment = toolCategory.Electricity,
            basicHandTools = toolCategory.Electricity,
            circuitProtection = toolCategory.Electricity,
            cableTools = toolCategory.Electricity,
            jacks = toolCategory.Automotive,
            airCompressors = toolCategory.Automotive,
            batteryChargers = toolCategory.Automotive,
            socketTools = toolCategory.Automotive,
            braking = toolCategory.Automotive,
            drivetrain = toolCategory.Automotive
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

        //public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public int Quantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public int AvailableQuantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public int NoBorrowings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        iMemberCollection iTool.GetBorrowers => throw new NotImplementedException();

        public Tool(toolCategory category, toolType toolType, String name, int quantity) {
            this.Category = category;
            this.Type = toolType;
            this.Name = name;
            this.Quantity = quantity;
            toolCategoryTypeInitialiser();
        }

        public Tool(toolCategory category, toolType toolType, int quantity)
        {
            this.Category = category;
            this.Type = toolType;
            this.Quantity = quantity;
        }

        public Hashtable getHT()
        {
            return toolHT;
        }
        public Tool() {
            toolCategoryTypeInitialiser();
        }

        void iTool.addBorrower(iMember aMember) {
            throw new NotImplementedException();
        }

        void iTool.deleteBorrower(iMember aMember) {
            throw new NotImplementedException();
        }

        void iTool.toolDetails() {
            throw new NotImplementedException();
        }
    }
}

