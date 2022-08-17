// See https://aka.ms/new-console-template for more information
//C:\\Users\\Admin\\source\\repos\\dataBaseProj\\dataForSoccerTeams.txt

using System.Diagnostics.Metrics;
using System.Xml.Linq;

class TeamNames{
    private String name;
    private String matchesPlayed;
    private String lastGame, lastgamePointsAgainst, amntPointsMade, pointsMadeAgainst;

    public TeamNames(String fname, String matchesPlayed, String lastGame, String lastGamePoints, String amntPoints, String pointsMade) {
        this.name = fname;
        this.matchesPlayed = matchesPlayed;
        this.lastGame = lastGame;
        this.lastgamePointsAgainst = lastGamePoints;
        this.amntPointsMade = amntPoints;
        this.pointsMadeAgainst = pointsMade;
    }
    
        public String getName() {
    return name;
    }
    public int GetPointsMade() { 
    return Int32.Parse(amntPointsMade);
    }

    public int teamDesiredScore() {
        return (GetPointsMade() - GetPointsMadeAgainst()) * GetMathchesPlayed();

    }
    public int GetPointsMadeAgainst() {
        return Int32.Parse(pointsMadeAgainst);
    }

    public int GetMathchesPlayed() { 
    return Int32.Parse(matchesPlayed);
    }

    override
    public String ToString() {
        return "SoccerTeam name is: " + this.name + "\nMatchesPlayed is: " + this.matchesPlayed +
            "\nlastGame score is: " + this.lastGame + "-" + this.lastgamePointsAgainst +  "\nAmount of points is: " +
            this.amntPointsMade + "\nPoints made against is: " + this.pointsMadeAgainst + "\n";
    }

    
}

class TeamReadIns {
    //private TeamNames[] teams;
    private TeamNames[] teams = new TeamNames[10];
    private int counter;

    public TeamReadIns() {
        //TeamNames[] teams = new TeamNames[10];
        
        this.counter = 0;
        try {
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\dataBaseProj\\dataForSoccerTeams.txt");

            foreach (string line in lines) {

                String[] s = line.Split(",");
                String a = s[0];
                String b = s[1];
                String c = s[2];
                String d = s[3];
                String e = s[4];
                String f = s[5];
                //for (int i = 0; i < 5; i++) {
                //  Console.WriteLine(s[i]);
                //}
                TeamNames t = new TeamNames(a, b, c, d, e, f);
                teams[counter++] = t;

            }
            // for (int i = 0; i < counter; i++)
            // {
            //       Console.WriteLine(teams[i].ToString());
            //  }

        }
        catch (IOException e) {
            Console.WriteLine(e);
        }
    }

    public void print() {
        for (int i = 0; i < counter ; i++) {
            Console.WriteLine(teams[i].ToString());
        }
    }

    public void add(TeamNames t) {
        teams[counter + 1] = t;
        counter++
    }

   
    /*
    public String newTeam(String name, String MatchesPlayed, String c, String d, String e, String f) {
    TeamNames b = new TeamNames(String name, String MatchesPlayed, String c, String d, String e, String f);
        b.add();
    }

    */
    public void Sort()
    {

        
        
        for (int i = 0; i < counter; i++)
            
        {
            for (int j = 0; j < counter - i; j++)
            {
                int b = teams[j].teamDesiredScore();
                TeamNames[] temp = new TeamNames[10];
                int t = teams[j].teamDesiredScore();
                if (teams[j + 1] != null)
                {
                     b = teams[j + 1].teamDesiredScore();
                }
                
                
                if (t < b) {
                      
                      temp[0] = teams[j];
                      teams[j] = teams[j+1];
                      teams[j+1] = temp[0];
                }
                //if (teams[j].teamDesiredScore() < teams[j+1].teamDesiredScore())
                // {
                //   temp[0] = teams[j];
                //   teams[j] = teams[i];
                //  teams[j] = temp[0];

                // }
            }
        }
    }
    public int pointsTotal(String name)
    {
       int pos = Search(name);
        return teams[pos].teamDesiredScore();

    }
    public void Print()
    {

        String sout = "";
        for (int i = 0; i < counter; i++)
        {
            sout += teams[i].ToString() + "\n";
        }
        Console.Write(sout);
    }

    public int Search(String teamName) {
        for (int i = 0; i < counter; i++) {
            if (teams[i].getName() == teamName)  {
            return i;
            }
        }
        return -1;
    }
    override
        public String ToString(){ 
    String sout = "";
        for (int i = 0; i < counter; i++) {
            
            sout += teams[i].getName() + " " + teams[i].teamDesiredScore()  +  "\n";
        }
        return sout;
    }
  

}

class Players { 
private String userName, teamName;
    public Players(String userName, String teamName) {
       this.userName = userName;
       this.teamName = teamName;
    }

    public String GetUserName() {
        return userName;
    }

    public String GetTeamName() {
        return teamName;
    }
    
    public int amntOfPoints(String teamName)
    {
        TeamReadIns i = new TeamReadIns();
        switch (teamName)
        {
            case "ManchesterUnited":
                return i.pointsTotal(teamName);

            case "Liverpool":
                return i.pointsTotal(teamName);

            case "Chelsea":
                return i.pointsTotal(teamName);

            case "Arsenal":
                return i.pointsTotal(teamName);

            case "CapeTown":
                return i.pointsTotal(teamName);
            default: return -1;
        }


    }

    


        public String toString() {
        
        return "Username: " + this.userName + "\nTeam: " + this.teamName;
    }
    
      
    
}

class LeaderBoard {
    private Players[] player = new Players[100];
    private int arr;

    public LeaderBoard() {
        this.arr = 0;
    }

    public void AddPlayer(Players t){
        player[arr] = t;
        arr++;
    }

    public void amnt(int amntOf)
    {
        for (int i = 0; i < amntOf; i++)
        {
            Details();
        }
    }
    public void Details() {
        String username;
        String teamName;
        Console.WriteLine("Please Write a username with no spaces");
        username = Console.ReadLine();
        Console.WriteLine("Please enter your team, one word and capitals at the begining of a word");
        teamName = Console.ReadLine();
        Players t = new Players(username, teamName);
        AddPlayer(t);
        //Console.WriteLine(player[arr-1].toString());
    }
    public void print() {
        for (int i = 0 ; i < arr; i++) {
            Console.WriteLine(player[i].GetUserName() + " has chosen: " + player[i].GetTeamName() + " and this team has " + player[i].amntOfPoints(player[i].GetTeamName()) + " amount of points"); 


        }
    }
    public void Sort()
    {



        for (int i = 0; i < arr; i++)

        {
            for (int j = 0; j < arr - i; j++)
            {
                int b = player[j].amntOfPoints(player[j].GetTeamName());
                Players[] temp = new Players[10];
                int t = player[j].amntOfPoints(player[j].GetTeamName());
                if (player[j + 1] != null)
                {
                    //Console.WriteLine(player[j].amntOfPoints(player[j].GetTeamName()));
                    b = player[j + 1].amntOfPoints(player[j + 1].GetTeamName());
                    
                }


                if (t < b)
                {
                    
                    temp[0] = player[j];
                    player[j] = player[j + 1];
                    player[j + 1] = temp[0];
                }
                
            }
        }
    }
    public String toString() {
        String sout = "";
        for (int i = 0; i < arr; i++)
        {
            sout += "Username " + i+1 +" is: " + player[i].GetUserName() + "\nTeam chosen was: " + player[i].GetTeamName() + "\n";
        }
        return sout;
    }

    



    }

    class main { 
static void Main(string[] args)
    {
        
        
        TeamReadIns t = new TeamReadIns();
        // t.Sort();
        //t.print();
        TeamNames b = new TeamNames();
        
        LeaderBoard l = new LeaderBoard();
        l.amnt(2);
        l.Sort();
        l.print();
       // t.Sort();
       // t.print();
        //t.print();
        //Console.WriteLine(t.ToString());
        //board.amnt(3);
        //Console.WriteLine(board.toString());
        
        //board.amntOfPoints(CapeTown);
        //TeamReadIns i = new TeamReadIns();
        //i.Print();
        //String userName;
        //Console.WriteLine("Enter Your Username");
        //userName = Console.ReadLine();
        //Console.WriteLine(userName); 
    }
}

