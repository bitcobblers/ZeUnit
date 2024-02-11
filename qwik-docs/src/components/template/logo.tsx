import { component$ } from "@builder.io/qwik"

const LogomarkPaths = component$(()=> {
    return (
      <g fill="none" stroke="#38BDF8" stroke-linejoin="round" stroke-width={3}>
        <path d="M10.308 5L18 17.5 10.308 30 2.615 17.5 10.308 5z" />
        <path d="M18 17.5L10.308 5h15.144l7.933 12.5M18 17.5h15.385L25.452 30H10.308L18 17.5z" />
      </g>
    )
  });
  
const Logomark = component$((props: any) => {
    return (
      <svg aria-hidden="true" viewBox="0 0 36 36" fill="none" {...props}>
        <LogomarkPaths />
      </svg>
    )
  });
  
const Logo = component$((props : { class: string}) => {
    return (        
        <span>
            <LogomarkPaths />
            <div class={props.class}>ZeUnit</div>
        </span>
               
    )
  });
export { LogomarkPaths, Logomark, Logo }