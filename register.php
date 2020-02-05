<?php include('server.php') ?>
<!DOCTYPE html>
<html>
<head>
	<title>BossFight Registration</title>
</head>
<body>
	<div>
		<h2>Register to BossFight</h2>
	</div>
	
	<form method="post" action="register.php">

		<?php include('errors.php'); ?>

		<div>
			<label>Username</label>
			<input type="text" name="username" value="<?php echo $username; ?>">
		</div>
			<label>Screen Name (What Players will See)</label>
			<input type="text" name="screenname" value="<?php echo $screenname; ?>">
		</div>
		<div>
			<label>Password</label>
			<input type="password" name="password_1">
		</div>
		<div>
			<label>Confirm password</label>
			<input type="password" name="password_2">
		</div>
		
		<div>
			<button type="submit" name="reg_user">Register</button>
		</div>
		<p>
			Already a member? <a href="login.php">Sign in</a>
		</p>
	</form>
</body>
</html>