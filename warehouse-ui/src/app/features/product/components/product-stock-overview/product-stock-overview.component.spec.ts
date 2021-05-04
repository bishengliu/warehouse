import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductStockOverviewComponent } from './product-stock-overview.component';

describe('ProductStockOverviewComponent', () => {
  let component: ProductStockOverviewComponent;
  let fixture: ComponentFixture<ProductStockOverviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductStockOverviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductStockOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
