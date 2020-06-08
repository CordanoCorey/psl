import { Collection } from '@caiu/library';

export class Dealer {
  id = 0;
  name = '';

  get dealerSrc(): string {
    return ``;
  }

  get logoSrc(): string {
    switch (this.id) {
      case 1:
        return 'assets/dealers/deer-country';
      case 2:
        return 'assets/dealers/campbell';
      case 3:
        return 'assets/dealers/campbell';
    }
    return null;
  }
}

export class Dealers extends Collection<Dealer> {
  constructor() {
    super(Dealer);
  }
}
