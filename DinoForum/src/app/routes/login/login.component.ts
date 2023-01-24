import { Component, OnInit } from '@angular/core';
import { LoginRequest } from 'src/app/models/httpRequests/login.request';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  userName: string = "";
  password: string = "";

  constructor(private authService: AuthService, private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    if (this.userService.getLoggedInUser()) {
      this.router.navigateByUrl('/');
    }
  }

  onSubmit() {
    const loginRequest = new LoginRequest();
    loginRequest.userName = this.userName;
    loginRequest.password = this.password;

    console.log(this.userName)

    this.authService.login(loginRequest).subscribe(
      (response) => {
        if (response.isAuthenticated) {
          this.userService.setLoggedInUser(response.user);
          this.router.navigateByUrl('/');
        } else {
          console.log(response.message);
          // Show an error message
        }
      },
      (error) => {
        console.log(error);
        // Show an error message
      }
    );


  }
}
