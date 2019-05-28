using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Sort
    {
        public string Title { get; set; }
        public string Year { get; set; }
    }
   
    public class Filter
    {
        public string title { get; set; }
    }

    public class MainRoot
    {
        public string title { get; set; }
        public List<string> Genres { get; set; }
        public string[] cast { get; set; }
        public int years { get; set; }
        public Sort Sort;
        public Filter filter;
    }

    public class Movie
    {
        public string title { get; set; }
        public int year { get; set; }
        public string[] cast { get; set; }
        public List<string> Genres { get; set; }
        
    }
    public  class Program
    {
    public static List<Movie> one;
    public static List<Movie> result = new List<Movie>();
    public static void Main(string[] args)
        {
         
              MainRoot Input= JsonConvert.DeserializeObject<MainRoot>(File.ReadAllText(@"C:\Users\rajesh.konki\Desktop\json\input.json"));
              one = JsonConvert.DeserializeObject<List<Movie>>(File.ReadAllText(@"C:\Users\rajesh.konki\Desktop\wikipedia-movie-data-master\wikipedia-movie-data-master\movies.json"));
        if (Input.title != null)
            foreach (var x in SearchTitle(Input.title))
                result.Add(x);
        foreach (var x in result)
        {
            Console.WriteLine(x.title);
            Console.WriteLine(x.year);
        }
        try
        {
            if (Input.years != 0)
                foreach (var x in YearSearch(Input.years))
                    result.Add(x);
        }catch(Exception e)
        {
            Console.WriteLine(e);
        }
        

        //Console.WriteLine(Input.years);
        //if (input.years != 0)
        //    yearsearch(input.years);
        //  List<string> rs = new List<string>();
        //foreach(var x in Input.cast)
        //  {
        //      rs.Add(x);


        //  }
        //  CastCheck(rs);

        Console.Read();
        
             //Console.WriteLine(obj.Title);
        }

    static IEnumerable<Movie> SearchTitle(String title)
    {
        var res = from x in one
                  where x.title.Contains(title)
                  select x;
        return res;
        //foreach (var i in res)
        //{
        //    Console.WriteLine(i.title);
        //    Console.WriteLine(i.year);
        //    foreach(var x in i.cast)
        //    Console.WriteLine(x);
        //    foreach (var x in i.Genres)
        //        Console.WriteLine(x);
        //    Console.WriteLine();


        //}
            
    }

    public static IEnumerable<Movie> YearSearch(int years)
    {
        
        

        var res = from x in result
                  where x.year==years
                  select x;
        return res;
        //foreach (var i in res)
        //{
        //    Console.WriteLine(i.title);
        //    Console.WriteLine(i.year);
        //    foreach (var x in i.cast)
        //        Console.WriteLine(x);
        //    foreach (var x in i.Genres)
        //        Console.WriteLine(x);
        //    Console.WriteLine();
        //}

    }

    public static IEnumerable<Movie> GeneresCheck(List<String> check)
    {
       
        var res = from x in one
                  where check.All(t1=>x.Genres.Contains(t1))
                
                  select x;
        return res;
     
        //foreach(var y in res)
        //{
        //    Console.WriteLine(y.title);
        //    foreach (var x in y.Genres)
        //        Console.WriteLine(x);
        //    Console.WriteLine();

        //}
    }

    public static IEnumerable<Movie> CastCheck(List<String> check)
    {

        var res = from x in one
                  where check.All(t1 => x.cast.Contains(t1))
                  select x;
        return res;
        //foreach (var y in res)
        //{
        //    Console.WriteLine(y.title);
        //    foreach (var x in y.cast)
        //        Console.WriteLine(x);
        //    Console.WriteLine();

        //}
    }



}

