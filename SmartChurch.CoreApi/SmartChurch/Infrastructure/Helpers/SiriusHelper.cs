using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using SmartChurch.DataModel.Models.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace SmartChurch.Infrastructure.Helpers
{
    public static class SiriusHelper
    {
        public static List<string> GetStringListFromEnum<T>() where T : struct
        {
            var t = typeof(T);
            return !t.IsEnum ? null : Enum.GetValues(t).Cast<Enum>().Select(x => x.ToString()).ToList();
        }

        public static string ConcatenateEnums<T>(List<T> enums, string delimiter) where T : struct
        {
            var sb = new StringBuilder();

            foreach (var thisEnum in enums)
            {
                sb.Append(thisEnum);
                sb.Append(delimiter);
            }

            sb.Remove(sb.Length - 1, delimiter.Length);

            return sb.ToString();
        }

        public static string ToFormattedTime(this DateTime dateTime)
        {
            return $"{dateTime:HH:mm}";
        }

        public static string ToFormattedDate(this DateTime dateTime)
        {
            return $"{dateTime:dd/MM/yyyy}";
        }

        public static string ToFormattedDateTime(this DateTime dateTime)
        {
            return $"{dateTime:dd/MM/yyyy - HH:mm}";
        }

        public static DateTime GetDateTimeFromTripModel(string vmDate, string vmTime)
        {
            var newDate = Convert.ToDateTime(vmDate);

            var timePiece1 = vmTime.Split(':');

            newDate = newDate.AddHours(Convert.ToInt32(timePiece1[0]));
            newDate = newDate.AddMinutes(Convert.ToInt32(timePiece1[1]));

            return newDate;
        }

        public static DateTime GetDateTimeFromTripModel(string vmDate, DateTime vmTime)
        {
            var newDate = Convert.ToDateTime(vmDate);

            var newTime = new TimeSpan(vmTime.Hour, vmTime.Minute, vmTime.Second);

            return newDate.Date + newTime;
        }
        
        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }

        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }

        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, 0, 0, 0);
        }

        public static DateTime EndOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month), 23, 59, 59);
        }

        public static bool IsDeletableEntity(this object obj)
        {
            return obj.GetType().GetProperty("IsDeleted") != null;
        }

        public static bool IsDeleted(this object obj)
        {
            return (bool)obj.GetType().GetProperty("IsDeleted").GetValue(obj);
        }

        /// <summary>
        /// /// Ignores auditing fields (Including delete)
        /// Must be used after ReverseMap() is called
        /// </summary>
        /// <typeparam name="TSource">Dto</typeparam>
        /// <typeparam name="TDestination">Entity</typeparam>
        /// <param name="expression">Result of reverse mapping</param>
        /// <returns>IMapping expression with ignored fields from auditing fields</returns>
        public static IMappingExpression<TSource, TDestination> IgnoreDeletableAuditingFields<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression) where TDestination: SiriusDeletableEntity
        {
            return expression
                .ForMember(x => x.IsDeleted, opt => opt.Ignore())
                .ForMember(x => x.Stamp, opt => opt.Ignore())
                .ForMember(x => x.CreationDate, opt => opt.Ignore())
                .ForMember(x => x.ModificationDate, opt => opt.Ignore())
                .ForMember(x => x.CreationUser, opt => opt.Ignore())
                .ForMember(x => x.ModificationUser, opt => opt.Ignore());
        }

        /// <summary>
        /// Ignores auditing fields (Not including delete)
        /// Must be used after ReverseMap() is called
        /// </summary>
        /// <typeparam name="TSource">Dto</typeparam>
        /// <typeparam name="TDestination">Entity</typeparam>
        /// <param name="expression">Result of reverse mapping</param>
        /// <returns>IMapping expression with ignored fields from auditing fields</returns>
        public static IMappingExpression<TSource, TDestination> IgnoreAuditingFields<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression) where TDestination: SiriusEntity
        {
            return expression
                .ForMember(x => x.Stamp, opt => opt.Ignore())
                .ForMember(x => x.CreationDate, opt => opt.Ignore())
                .ForMember(x => x.ModificationDate, opt => opt.Ignore())
                .ForMember(x => x.CreationUser, opt => opt.Ignore())
                .ForMember(x => x.ModificationUser, opt => opt.Ignore());
        }
    }

    //https://github.com/aspnet/Mvc/issues/6711
    public static class TempDataExtensions
    {
        public static void Set<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value, Formatting.None,
                new JsonSerializerSettings()
                { 
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            tempData.TryGetValue(key, out var o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }

        public static T Peek<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            var o = tempData.Peek(key);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            var rawTripLocations = value;
            var serializedTripLocations = JsonConvert.SerializeObject(rawTripLocations);
            session.SetString(key, serializedTripLocations);
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "Session is empty!");
            }

            var deserializedValue = JsonConvert.DeserializeObject<T>(value);

            return deserializedValue;
        }
    }
}