import { Component, OnInit } from '@angular/core';
import { AuthService } from '@core/services';
import { environment } from '@env';
import { Menu } from '../../model/menu';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.sass']
})
export class HeaderComponent implements OnInit {
  
  // private appUser : AppUserAu  th = new AppUserAuth();

  isCollapsed = true;
  title = environment.appName;
  menu: Menu[] = [
    {
      name: "Cadastre sua suspeita", 
      route: ""
    },
    {
      name: "Ranking", 
      route: ""
    },
  ];

  constructor(private authService : AuthService) { 
    let appUser = authService.getLogin();

    console.log(appUser);
  }

  ngOnInit(): void {

  }

}
