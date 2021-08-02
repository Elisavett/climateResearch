using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace climateResearch.Models
{
    public class ClimateBaseInitializer : DropCreateDatabaseAlways<ClimateDbContext>
    {
        protected override void Seed(ClimateDbContext context)
        {
            //Пункты наблюдения
            var observationPoints = new List<ObservationPoint>
            {
                new ObservationPoint {Name = "Автоматизированная метеорологическая информационно-измерительная система и визуальные наблюдения", Description = "(АМИИС)", Latitude=43.32m, Longtitude=72.12m},
                new ObservationPoint {Name = "Автоматизированный метеорологический (акустический) комплекс", Description = "АМК-03", Latitude=62.88m, Longtitude=103.6m},
                new ObservationPoint {Name = "Многоканальный среднего разрешения фильтровый радиометр", Description = "NILU-UV-6T", Latitude=54.22m, Longtitude=107.62m},
                new ObservationPoint {Name = "Солнечный многоволновой фотометр SP-8(9)", Description = "T", Latitude=74.82m, Longtitude=112.6m},
            };
            observationPoints.ForEach(op => context.ObservationPoints.AddOrUpdate(op));

            //Средства измерения в пунктах наблюдения
            var measuringInstruments = new List<MeasuringInstrument>
            {
                new MeasuringInstrument {Name="Vaisala HMP-45D", Description="датчики температуры и влажности", ObservationPoint=observationPoints[0]},
                new MeasuringInstrument {Name="анеморумбометр М-63М", Description="", ObservationPoint=observationPoints[0]},
                new MeasuringInstrument {Name="барометр ртутный СР-А", Description="барограф М-22АН", ObservationPoint=observationPoints[0]},
                new MeasuringInstrument {Name="прибор № 23", Description="", ObservationPoint=observationPoints[1]},
                new MeasuringInstrument {Name="прибор № 26", Description="", ObservationPoint=observationPoints[1]},
                new MeasuringInstrument {Name="прибор № 04117", Description="", ObservationPoint=observationPoints[2]},
            };
            measuringInstruments.ForEach(mi => context.MeasuringInstruments.AddOrUpdate(mi));

            //Физические величины
            var physicalQuantities = new List<PhysicalQuantity>
            {
                new PhysicalQuantity {Name="Температура воздуха", Designation="t", Unit="°C"},
                new PhysicalQuantity {Name="Атмосферное давление", Designation="p", Unit="гПа"},
                new PhysicalQuantity {Name="Относительная влажность воздуха", Designation="f", Unit="%"},
            };
            physicalQuantities.ForEach(pq => context.PhysicalQuantities.AddOrUpdate(pq));

            //Датчики средств измерения и физ. величин
            var sensors = new List<Sensor>
            {
                new Sensor {Name = "датчик температуры", MeasurementMode="непрерывный, автоматический", Designation="4402", DbName="apik3", DbTable="50000022", MeasuringInstrument=measuringInstruments[0], PhysicalQuantity=physicalQuantities[0]},
                new Sensor {Name = "датчик влажности", MeasurementMode="непрерывный, автоматический", Designation="5402", DbName="apik3", DbTable="50000022", MeasuringInstrument=measuringInstruments[0], PhysicalQuantity=physicalQuantities[2]},
                new Sensor {Name = "датчик 14", MeasurementMode="периодический, ручной", Designation="701", DbName="apik3", DbTable="50000022", MeasuringInstrument=measuringInstruments[1], PhysicalQuantity=physicalQuantities[1]},
                new Sensor {Name = "датчик 55", MeasurementMode="непрерывный, автоматический", Designation="701", DbName="apik3", DbTable="50000022", MeasuringInstrument=measuringInstruments[2], PhysicalQuantity=physicalQuantities[1]},
                new Sensor {Name = "датчик температуры", MeasurementMode="непрерывный, автоматический", Designation="2000", DbName="apik3", DbTable="50000022", MeasuringInstrument=measuringInstruments[3], PhysicalQuantity=physicalQuantities[0]},
                new Sensor {Name = "датчик влажности", MeasurementMode="непрерывный, автоматический", Designation="8001", DbName="apik3", DbTable="50000022", MeasuringInstrument=measuringInstruments[3], PhysicalQuantity=physicalQuantities[2]},
                new Sensor {Name = "датчик 15", MeasurementMode="периодический, ручной", Designation="701", DbName="apik3", DbTable="50000022", MeasuringInstrument=measuringInstruments[4], PhysicalQuantity=physicalQuantities[1]},
                new Sensor {Name = "датчик 12", MeasurementMode="непрерывный, автоматический", Designation="701", DbName="apik3", DbTable="50000022", MeasuringInstrument=measuringInstruments[5], PhysicalQuantity=physicalQuantities[1]},
                new Sensor {Name = "датчик 166", MeasurementMode="непрерывный, автоматический", Designation="2005", DbName="apik3", DbTable="50000022", MeasuringInstrument=measuringInstruments[5], PhysicalQuantity=physicalQuantities[0]},
            };
            sensors.ForEach(s => context.Sensors.AddOrUpdate(s));
        }
    }
}