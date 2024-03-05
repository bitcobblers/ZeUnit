import { component$, useStore } from "@builder.io/qwik"
import Navigation from "./navigation";
import { Logo } from "./logo";
import GitHubIcon from "./git-hub-icon";
// import { Link } from "@builder.io/qwik-city";
// import { Logomark } from "./logo";

const MenuIcon = component$((props: any) => {
  return (
    <svg
      aria-hidden="true"
      viewBox="0 0 24 24"
      fill="none"
      strokeWidth="2"
      strokeLinecap="round"
      {...props}
    >
      <path d="M4 7h16M4 12h16M4 17h16" />
    </svg>
  )
})

const CloseIcon = component$((props: any) => {
  return (
    <svg
      aria-hidden="true"
      viewBox="0 0 24 24"
      fill="none"
      strokeWidth="2"
      strokeLinecap="round"
      {...props}
    >
      <path d="M5 5l14 14M19 5l-14 14" />
    </svg>
  )
});

export default component$(() => {
  const menu = useStore({ isOpen: false});  
  return (
    <>
      <div class="w-full">
      <div class="relative flex w-full">
        <div class="pt-2 md:pt-4">
          <Logo class="flex-0 block fill-slate-700 dark:fill-sky-100 text-2xl " />
        </div>
        <div class="grow"></div>
        <div class="pt-3 md:pt-5 md:pr-5">
          <a href="https://github.com/bitcobblers/ZeUnit/" target="_blank" class="group" aria-label="ZeUnit repository on GitHub">
            <GitHubIcon class="h-6 w-6 fill-slate-400 group-hover:fill-slate-500 dark:group-hover:fill-slate-300" />
          </a>
        </div>        
          {!menu.isOpen 
           ? <button
           type="button"
           onClick$={() => menu.isOpen = true}
           aria-label="Open navigation"
         ><MenuIcon class="h-6 w-6 stroke-slate-500" /></button>
           : <button
           type="button"
           onClick$={() => menu.isOpen = false}
           aria-label="Close navigation"
         >                
           <CloseIcon class="h-6 w-6 stroke-slate-500" />
           </button>
          }        
      </div>
      {menu.isOpen 
        ? <div
          class="flex z-50 items-start w-full"
          aria-label="Navigation"
        >
          <div class="h-full w-full bg-white px-4 pb-12 pt-5 sm:px-6 dark:bg-slate-900">            
            <Navigation />
          </div>
        </div> 
        : <></>
      }
      </div>
    </>
  )
});
