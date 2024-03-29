import { Component, OnInit, ElementRef, Input, Output, EventEmitter } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { SmartComponent, sidenavOpenedSelector, windowHeightSelector, windowWidthSelector, SidenavActions, routeNameSelector, CurrentUserActions, Image, build } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { CurrentUser } from '../models';
import { currentUserSelector } from '../selectors';

@Component({
  selector: 'psl-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.scss'],
  animations: [
    trigger('sidenavState', [
      state(
        'closed',
        style({
          width: '0px'
        })
      ),
      state(
        'open',
        style({
          width: '335px'
        })
      ),
      transition('closed => open', animate('350ms ease-in')),
      transition('open => closed', animate('350ms ease-out'))
    ]),
    trigger('contentState', [
      state(
        'closed',
        style({
          left: '0px'
        })
      ),
      state(
        'open',
        style({
          left: '335px'
        })
      ),
      transition('closed => open', animate('350ms ease-in')),
      transition('open => closed', animate('350ms ease-out'))
    ])
  ]
})
export class ContainerComponent extends SmartComponent implements OnInit {
  @Input() hasWallpaper = true;
  @Output() scrolling = new EventEmitter<number>();
  currentUser: CurrentUser = new CurrentUser();
  currentUser$: Observable<CurrentUser>;
  isDarkTheme = true;
  routeName = '';
  routeName$: Observable<string>;
  sidenavOpened = true;
  sidenavOpened$: Observable<boolean>;
  windowHeight = 0;
  windowHeight$: Observable<number>;
  windowWidth = 0;
  windowWidth$: Observable<number>;
  images: Image[] = [
    build(Image, {
      src: 'assets/products/category-4wd.png',
      height: 437,
      width: 779
    }),

    build(Image, {
      src: 'assets/products/category-compact.png',
      height: 437,
      width: 777
    }),

    build(Image, {
      src: 'assets/products/category-rowcrop.png',
      height: 541,
      width: 961
    }),

    build(Image, {
      src: 'assets/products/category-specialty.png',
      height: 437,
      width: 777
    }),
    build(Image, {
      src: 'assets/products/category-utility.png',
      height: 437,
      width: 777
    }),
    // build(Image, {
    //   src: 'assets/products/compact-1series.png',
    //   height: 304,
    //   width: 321
    // }),
    // build(Image, {
    //   src: 'assets/products/compact-2series.png',
    //   height: 304,
    //   width: 398
    // }),
    // build(Image, {
    //   src: 'assets/products/compact-3series.png',
    //   height: 279,
    //   width: 499
    // }),
    // build(Image, {
    //   src: 'assets/products/compact-4series.png',
    //   height: 295,
    //   width: 434
    // }),
    // build(Image, {
    //   src: 'assets/products/specialty-5075GL.png',
    //   height: 655,
    //   width: 762
    // }),
    // build(Image, {
    //   src: 'assets/products/specialty-5090EL.png',
    //   height: 621,
    //   width: 859
    // }),
    // build(Image, {
    //   src: 'assets/products/specialty-5100ML.png',
    //   height: 567,
    //   width: 804
    // }),
    // build(Image, {
    //   src: 'assets/products/specialty-5115ML.png',
    //   height: 653,
    //   width: 983
    // }),
    // build(Image, {
    //   src: 'assets/products/specialty-5125ML.png',
    //   height: 556,
    //   width: 831
    // })
  ];

  constructor(public store: Store<any>, private elementRef: ElementRef) {
    super(store);
    this.routeName$ = routeNameSelector(store);
    this.sidenavOpened$ = sidenavOpenedSelector(store);
    this.windowHeight$ = windowHeightSelector(store);
    this.windowWidth$ = windowWidthSelector(store);
    this.currentUser$ = currentUserSelector(store);
  }

  get isMobile(): boolean {
    return (
      /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ||
      (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(
        navigator.userAgent
      ) ||
        /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(
          navigator.userAgent.substr(0, 4)
        ))
    );
  }

  get contentWidth(): number {
    return this.windowWidth - this.contentWidth;
  }

  get showWallpaper() {
    return this.hasWallpaper && !this.isMobile;
  }

  get sidenavWidth(): number {
    // return this.sidenavOpened ? (this.isMobile ? this.windowWidth : 135) : 0;
    return this.sidenavOpened ? 335 : 0;
  }

  ngOnInit() {
    this.sync(['currentUser', 'routeName', 'sidenavOpened', 'windowHeight', 'windowWidth']);
  }

  onScroll(e) {
    const scrollTop = e.srcElement.scrollTop;
    this.scrolling.emit(scrollTop);
  }

  closeSidenav() {
    this.dispatch(SidenavActions.close());
  }

  logout() {
    this.dispatch(CurrentUserActions.logout());
  }

  openSidenav() {
    this.dispatch(SidenavActions.open());
  }

  resetWindowHeight() {
    if (this.elementRef && this.elementRef.nativeElement) {
      this.elementRef.nativeElement.style.height = `${this.windowHeight}px`;
    }
  }

  resetWindowWidth() {
    if (this.elementRef && this.elementRef.nativeElement) {
      this.elementRef.nativeElement.style.width = `${this.windowWidth}px`;
    }
  }

  toggleSidenav() {
    this.store.dispatch(SidenavActions.toggle());
  }
}
