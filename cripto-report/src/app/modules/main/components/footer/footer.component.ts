import { Component, OnInit } from '@angular/core';
import { environment } from '@env';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.sass']
})
export class FooterComponent implements OnInit {
  title = environment.appName
  constructor() { }

  ngOnInit(): void {
  }

}
