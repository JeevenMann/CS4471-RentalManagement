//Add MySql Library
using MySql.Data.MySqlClient;

class DBConnect
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    //Constructor
    public DBConnect()
    {
        Initialize();
    }

    //Initialize values
    private void Initialize()
    {
        server = "cs4471db.cek2uenwafvt.us-east-2.rds.amazonaws.com";
        database = "cs4471Project";
        //or it could be css4471db
        uid = "admin";
        password = "cs4471rocks";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
		database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
    }

        //open connection to database
    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                    MessageBox.Show("Cannot connect to server.  Contact administrator");
                    break;

                case 1045:
                    MessageBox.Show("Invalid username/password, please try again");
                    break;
            }
            return false;
        }
    }

    //Close connection
    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }
        
    // --------------------------- Insert Functions ------------------------------ //
    //Insert statement
    public void InsertCustomer(string name, Guid guid)
    {
        string query = $"INSERT INTO customers (customer_name, balance, amount_paid) VALUES('{name}', '0', '0',{guid.ToString()})";

        //open connection
        if (this.OpenConnection() == true)
        {
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);
            
            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
        }
    }

    public void InsertItem(string name, double cost, int stock)
    {
        string query = $"INSERT INTO items (item_name, cost, stock) VALUES('{name}', '{cost}', '{stock}')";
        //open connection
        if (this.OpenConnection() == true)
        {
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);
            
            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
        }
    }

    public void RentItem(string custName, string itemName, int cost)
    {
        string query = $"INSERT INTO rents (customer_name, item_name, rent_cost, date_rented) VALUES('{custName}', '{itemName}', '{cost}',CURDATE())";
        IncreaseStock();

        //open connection
        if (this.OpenConnection() == true)
        {
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);
            
            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
        }
    }

    // --------------------------- Update Data ------------------------------ //

    //Update statement
    public void IncreaseStock(string itemName)
    {
        string query = $"UPDATE items SET stock = stock + 1 WHERE item_name ='{itemName}'";

        //Open connection
        if (this.OpenConnection() == true)
        {
            //create mysql command
            MySqlCommand cmd = new MySqlCommand();
            //Assign the query using CommandText
            cmd.CommandText = query;
            //Assign the connection using Connection
            cmd.Connection = connection;

            //Execute query
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
        }
    }

    //Update statement
    public void DecreaseStock()
    {
        string query = $"UPDATE items SET stock = stock - 1 WHERE item_name ='{itemName}'";

        //Open connection
        if (this.OpenConnection() == true)
        {
            //create mysql command
            MySqlCommand cmd = new MySqlCommand();
            //Assign the query using CommandText
            cmd.CommandText = query;
            //Assign the connection using Connection
            cmd.Connection = connection;

            //Execute query
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
        }
    }

    //Update statement
    public void Update()
    {
        string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

        //Open connection
        if (this.OpenConnection() == true)
        {
            //create mysql command
            MySqlCommand cmd = new MySqlCommand();
            //Assign the query using CommandText
            cmd.CommandText = query;
            //Assign the connection using Connection
            cmd.Connection = connection;

            //Execute query
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
        }
    }

    // --------------------------- Delete Data ------------------------------ //

    //Delete Item statement
    public void DeleteItem(string itemName)
    {
        string query = $"DELETE FROM items WHERE item_name='{itemName}'";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }

    //Delete statement
    public void DeleteCustomer(string customerName)
    {
        string query = $"DELETE FROM customers WHERE customer_name='{customerName}'";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }

    //Return Item statement
    public void ReturnItem(string customerName, string itemName)
    {
        string query = $"DELETE FROM rents WHERE item_name='{itemName} AND customer_name='{customerName}'";
        DecreaseStock();
        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }

    //Select statement
    public List< string >[] Select()
    {
        string query = "SELECT * FROM tableinfo";

        //Create a list to store the result
        List< string >[] list = new List< string >[3];
        list[0] = new List< string >();
        list[1] = new List< string >();
        list[2] = new List< string >();

        //Open connection
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            
            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["id"] + "");
                list[1].Add(dataReader["name"] + "");
                list[2].Add(dataReader["age"] + "");
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return list;
        }
        else
        {
            return list;
        }
    }

    //Count statement
    public int Count()
    {
    }

    //Backup
    public void Backup()
    {
    }

    //Restore
    public void Restore()
    {
    }
}