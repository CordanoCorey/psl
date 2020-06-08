import { Metadata, build, Validators, Collection, CurrentUser as BaseCurrentUser, toArray, compareNumbers, toInt, QueryModel } from '@caiu/library';

export { BaseEntity } from '@caiu/library';

export class User {
  id = 0;
  email = '';
  firstName = '';
  lastName = '';
  active = true;
  locked = false;

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: [
        'accessFailedCount',
        'concurrencyStamp',
        'createdById',
        'createdByName',
        'createdDate',
        'emailConfirmed',
        'lastModifiedById',
        'lastModifiedByName',
        'lastModifiedDate',
        'lockoutEnabled',
        'lockoutEnd',
        'normalizedEmail',
        'normalizedUserName',
        'password',
        'passwordHash',
        'passwordResetCode',
        'phoneNumber',
        'phoneNumberConfirmed',
        'securityStamp',
        'twoFactorEnabled',
        'userName'
      ]
    });
  }
}

export class Users extends Collection<User> {

  usersLoaded = false;

  constructor() {
    super(User);
  }

  update(data: User | User[]): Users {
    return build(Users, super.update(data), { usersLoaded: true });
  }
}

export class CurrentUser extends BaseCurrentUser {
  static Build(data: any): CurrentUser {
    return build(CurrentUser, BaseCurrentUser.Build(data));
  }

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: ['id', 'expiresInDate', 'isAdmin', 'password', 'passwordResetCode', 'role', 'token']
    });
  }
}

export class Account {

}

export class Accounts extends Collection<Account> {
  constructor() {
    super(Account);
  }
}

export interface Distance {
  x: number;
  y: number;
  zIndex?: number;
}

export class Login {
  email = '';
  password = '';

  get metadata(): Metadata {
    return build(Metadata, {
      email: {
        validators: [Validators.required, Validators.email]
      }
    });
  }
}

export class UsersQuery extends QueryModel<User> {

}

export class Widget {
  id = 0;
  name = '';
  userId = 0;
  height = 0;
  heightPx = 0;
  justifyX: 'LEFT' | 'RIGHT' | 'CENTER';
  justifyY: 'TOP' | 'BOTTOM' | 'CENTER';
  offsetX = 0;
  label = '';
  left = 0;
  offsetY = 0;
  top = 0;
  width = 0;
  widthPx = 0;
  zIndex = 0;
}

export class Widgets extends Collection<Widget> {

  constructor() {
    super(Widget);
  }

  update(data: Widget | Widget[]): Widgets {
    return build(Widgets, super.update(data));
  }
}

export class ImageOverlay {
  src = '';
  top = 0;
  left = 0;
  height = 0;
  width = 0;
}
