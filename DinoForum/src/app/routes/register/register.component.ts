import { Component, OnInit } from '@angular/core';
import { RegisterRequest } from 'src/app/models/httpRequests/register.request';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  userName: string = "";
  password: string = "";

  constructor(private authService: AuthService, private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    if (this.userService.getLoggedInUser()) {
      this.router.navigateByUrl('/');
    }
  }

  onSubmit() {
    const registerRequest = new RegisterRequest();
    registerRequest.userName = this.userName;
    registerRequest.password = this.password;

    console.log(this.userName)

    this.authService.register(registerRequest).subscribe(
      (response) => {
        if (response.isRegistered) {
          this.router.navigateByUrl('/login');
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
