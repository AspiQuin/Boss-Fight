<?php
	if (!isset($_SESSION)) {
		session_start(); 
	}	

include "server_connection.php";
	// variable declaration
	$username = "";
	$screenname = "";
	$errors = array(); 
	$_SESSION['success'] = "";
	//$_SESSION['permissions'] = 0;

	// connect to database
	
	$conn = new mysqli($servername, $server_username, $server_password, $dbname);
	
	// Check connection
	if ($conn->connect_error){
		die("Connection failed: " . $conn->connect_error);
	}
	
	// REGISTER USER
	if (isset($_POST['reg_user'])) {
		// receive all input values from the form
		$username	= mysqli_real_escape_string($conn, $_POST['username']);
		$screenname	= mysqli_real_escape_string($conn, $_POST['screenname']);
		$password_1	= mysqli_real_escape_string($conn, $_POST['password_1']);
		$password_2	= mysqli_real_escape_string($conn, $_POST['password_2']);

		// form validation: ensure that the form is correctly filled
		if (empty($username)) { array_push($errors, "Username is required"); }
		if (empty($screenname)) { array_push($errors, "Screen Name is required"); }
		if (empty($password_1)) { array_push($errors, "Password is required"); }

		if ($password_1 != $password_2) {
			array_push($errors, "The two passwords do not match");
		}
		

		// check if username exists
		$query = "SELECT * FROM BOSSFIGHTUSERS WHERE username='$username'";
		$results = $conn->query($query);
		
		if($results->num_rows !=  0){
			array_push($errors, "This username already exists");
		}
			
			
		
		// register user if there are no errors in the form
		if (count($errors) == 0) {
			$password = $password_1;

			$query = "INSERT INTO BOSSFIGHTUSERS (username, screenname, password) 
					  VALUES('$username', '$screenname', '$password')";
			
			if($conn->query($query) === TRUE){
				echo "You are registered successfully<br>";
			}else{
				echo "Error: " . $sql . "<br>" . $conn->error;
			}
			
			$query = "SELECT * FROM BOSSFIGHTUSERS WHERE username='$username'";
			$results = $conn->query($query);		
			$_SESSION['username'] = $username;
			$_SESSION['success'] = "You are now logged in";

		
			header('location: index.php');

		}
	}

	// ... 
		// LOGIN USER
	if (isset($_POST['login_user'])) {
		$username = mysqli_real_escape_string($conn, $_POST['username']);
		$password = mysqli_real_escape_string($conn, $_POST['password']);

		
		if (empty($username)) {
			array_push($errors, "Username is required");
		}
		if (empty($password)) {
			array_push($errors, "Password is required");
		}

		if (count($errors) == 0) {

			$query = "SELECT * FROM BOSSFIGHTUSERS WHERE username='$username' AND password='$password'";
			echo "<br>", $query,"<br>";

			$results = $conn->query($query);

			echo "Number of rows returned: ".$results->num_rows."<br>";

			if($results->num_rows ==  1){
				$_SESSION['username'] = $username;
				$_SESSION['success'] = "You are now logged in";
				header('location: index.php');
			}
			}
			else 
			{
				echo "Please enter a registered username/password";
				array_push($errors, "Wrong username/password combination");
			}
		
	}
	$conn->close();
	
?>