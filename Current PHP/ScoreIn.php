<?php
	$servername = "ugrad.bitdegree.ca";
	$server_username = "erinwaldram";
	$server_password = "_Ps0qfH2NR";
	$dbname = "erinwaldram";
	
	//variables submitted by user
	$currentUser = $_POST["currentUser"];
	$userScore = $_POST["userScore"];
	
	//Create Connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbname);
	
	// Check connection
	if ($conn->connect_error){
		die("Connection failed: " . $conn->connect_error);
	}
	
	$sql = "SELECT username FROM BOSSFIGHTUSERS WHERE username = '". $currentUser . "'";
	
	$result = $conn-> query ($sql);
	
	if ($result -> num_rows < 0) {
	//Tell user that they don't have a score yet
		echo "User does not exist";
	}
	else {
		$sql2 = "UPDATE BOSSFIGHTUSERS SET user_score = '" . $userScore . "'  WHERE username = '". $currentUser. "'";
		
		if($conn -> query($sql2) === TRUE) {
			echo "Score has been added";
		}
		else {
			echo "Error: " . $sql2 . "<br>" . $conn->error;
		}
	}
	$conn -> close();
	
?>