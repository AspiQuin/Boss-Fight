<?php
	$servername = "ugrad.bitdegree.ca";
	$server_username = "erinwaldram";
	$server_password = "_Ps0qfH2NR";
	$dbname = "erinwaldram";
	
	//variables to be returned to the user
	//$currentUser = $_POST["currentUser"];
	//$userScore = $_POST["userScore"];
	
	//Create Connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbname);
	
	// Check connection
	if ($conn->connect_error){
		die("Connection failed: " . $conn->connect_error);
	}
	
	$sql = "SELECT * FROM BOSSFIGHTUSERS ORDER BY user_score DESC LIMIT 5";
	
	$result = $conn-> query ($sql);

	
	if ($result -> num_rows >0) {
	//Return values
		while($row = mysqli_fetch_array($result)) {
			echo $row['screenname'] . "                               ";
			echo $row['user_score'] .  "\n";
		}
	}
	else {
		echo "Error: " . $sql . "<br>" . $conn->error;
	}
	$conn -> close();
	
?>