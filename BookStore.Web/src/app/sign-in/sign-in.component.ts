import { Component, OnInit } from '@angular/core';
import { JwtService } from '../services/jwt.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { User } from '../models/user';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(private jwtService: JwtService, private toastrService: ToastrService, private router: Router) { }

  user = new User();

  ngOnInit() {
    if (this.jwtService.TokenControl) {
      this.router.navigate(['home']);
    }
  }
  onLogin() {
    localStorage.removeItem('bookMapToken');
    this.jwtService.GetToken(this.user).subscribe(
      (res: any) => {
        if (res.IsSuccess) {
          if (res.Result === '0') {
            this.toastrService.error('Giriş bilgilerini kontrol ederek, tekrar deneyiniz.', 'Kullanıcı Girişi Hatalı');
          } else {
            const token = res.Result.substring(0, res.Result.length - 1).substring(1, res.Result.length);
            localStorage.setItem('bookMapToken', token);
            this.router.navigate(['home']);
          }
        }
      });
  }
}
