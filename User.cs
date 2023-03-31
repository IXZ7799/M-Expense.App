using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace M_Expense;

[Table("User")]
public class User
{
    [MaxLength(250)]
    public string TripName { get; set; }
    public string Destination { get; set; }
    public string TripDate { get; set; }
    public string RiskAssessment { get; set; }
    public string TripDesc { get; set; }
    public int PeopleAttending { get; set; }
    public string Transportation { get; set; }

    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string ImageName { get; set; }

    public User()
    {
        ID = 0;
        ImageName = UserSQLiteDatabase.DEFAULT_IMAGE;
    }

    public User(string inTripName, string inDestination, string inTripDate, string inRiskAssessment, string inTripDesc, int inPeopleAttending, string inTransportation, int inID)
    {
        TripName = inTripName;
        Destination = inDestination;
        TripDate = inTripDate;
        RiskAssessment = inRiskAssessment;
        TripDesc = inTripDesc;
        PeopleAttending = inPeopleAttending;
        Transportation = inTransportation;
        ID = inID;
        ImageName = UserSQLiteDatabase.DEFAULT_IMAGE;
    }

    public User(string inTripName, string inDestination, string inTripDate, string inRiskAssessment, string inTripDesc, int inPeopleAttending, string inTransportation, int inID, string inImageName)
    {
        TripName = inTripName;
        Destination = inDestination;
        TripDate = inTripDate;
        RiskAssessment = inRiskAssessment;
        TripDesc = inTripDesc;
        PeopleAttending = inPeopleAttending;
        Transportation = inTransportation;
        ID = inID;
        ImageName = inImageName;
    }
}
