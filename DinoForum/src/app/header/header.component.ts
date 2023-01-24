import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  userName: string;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.userName = this.userService.getLoggedInUser().userName;
  }

  logout() {
    this.userService.deleteLoggedInUser();
    this.router.navigate(['/login']);
  }

  createNewPost() {
    this.router.navigate(['/new-post']);
  }
}
