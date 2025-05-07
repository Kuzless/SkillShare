import { Component } from '@angular/core';
import { LoginService } from '../login-service/login.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-auth',
  imports: [FormsModule],
  providers: [LoginService],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css',
  standalone: true,
})
export class AuthComponent {
  email: string = '';
  password: string = '';
  loginService: LoginService;
  constructor(loginService: LoginService) {
    this.loginService = loginService;
  }

  login() {
    this.loginService.login(this.email, this.password).subscribe();
  }
}
