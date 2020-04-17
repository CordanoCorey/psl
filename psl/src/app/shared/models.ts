import { Metadata, build, Validators, Collection, CurrentUser as BaseCurrentUser, toArray, compareNumbers, toInt, QueryModel } from '@caiu/library';

export { BaseEntity } from '@caiu/library';

export class User {
  id = 0;
  email = '';
  firstName = '';
  lastName = '';
  order = 0;
  paid = false;
  pickToWinName = 'N/A';
  place = '';
  totalPoints = 0;
}

export class Users extends Collection<User> {

  static AssignPlaces(data: User[]): User[] {
    const groupedByPointTotal = data.reduce((acc, x) => Object.assign({}, acc, { [x.totalPoints]: [...toArray(acc[x.totalPoints]), x] }), {});
    return Object.keys(groupedByPointTotal).sort((a, b) => compareNumbers(toInt(a), toInt(b))).reverse()
      .map((pts, i) => groupedByPointTotal[pts].map(y => build(User, y, {
        order: i + 1,
        place: groupedByPointTotal[pts].length > 1 ? `T${i + 1}` : `${i + 1}`
      }))).reduce((acc, x) => [...acc, ...x], []);
  }

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
