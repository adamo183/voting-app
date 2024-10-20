import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Product } from "../../models/product";
import { environment } from "../config/environment";
import { ProductFilter } from "../../models/productFilter";
import { map } from "rxjs/operators";
import { Observable } from "rxjs/internal/Observable";

@Injectable({
  providedIn: 'root'
})
export class VotingService {
  
    constructor(
      private httpClient: HttpClient) { }
  
}