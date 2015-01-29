using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Point;

static class Storage
{
    private const string PathMatcher = @"Path:\s+((?:Point\s*\((?:.*?),\s*(?:.*?),\s*(?:.*?)\)\s*)+)";
    private const string PointMatcher = @"Point\s*\((.*?),\s*(.*?),\s*(.*?)\)";

    public static void SavePathToFile(string fileLocation, Path3D path)
    {
        File.WriteAllText(fileLocation, path.ToString());
    }

    /// <summary>
    /// Searches for the first occurrence of a Path string in the source file and returns a Path3D object.
    /// </summary>
    /// <param name="fileLocation">The path to the file being read.</param>
    /// <returns>A Path3D object</returns>
    public static Path3D LoadPathFromFile(string fileLocation)
    {
        string input = File.ReadAllText(fileLocation);
        if (!Regex.IsMatch(input, PathMatcher))
        {
            throw new ArgumentNullException("input", "File does not contain Path3D data.");
        }

        string pathAsString = Regex.Match(input, PathMatcher).Groups[1].Value;
        var pointsInPath = new List<Point3D>();
        foreach (Match match in Regex.Matches(pathAsString, PointMatcher))
        {
            double xCoordinate = double.Parse(match.Groups[1].Value);
            double yCoordinate = double.Parse(match.Groups[2].Value);
            double zCoordinate = double.Parse(match.Groups[3].Value);
            pointsInPath.Add(new Point3D(xCoordinate, yCoordinate, zCoordinate));
        }

        Path3D pathFromFile = new Path3D(pointsInPath);
        return pathFromFile;
    }
}

