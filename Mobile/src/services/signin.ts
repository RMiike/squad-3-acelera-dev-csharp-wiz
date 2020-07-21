interface Response {
  token: string;
  user: {
    fullname: string;
    email: string;
  };
}

export function signIn(): Promise<Response> {
  return new Promise((r) => {
    setTimeout(() => {
      r({
        token: 'Bearer poaskdopaskdopsak123sd123',
        user: {
          fullname: 'Renato',
          email: 'miike@gmail.com',
        },
      });
    }, 300);
  });
}
